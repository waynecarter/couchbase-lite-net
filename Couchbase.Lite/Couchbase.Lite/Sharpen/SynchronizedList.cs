//
// SynchronizedList.cs
//
// Author:
//     Zachary Gramana  <zack@xamarin.com>
//
// Copyright (c) 2014 Xamarin Inc
// Copyright (c) 2014 .NET Foundation
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//
// Copyright (c) 2014 Couchbase, Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
// except in compliance with the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.
//

namespace Sharpen
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;

	internal class SynchronizedList<T> : IEnumerable, ICollection<T>, IList<T>, IEnumerable<T>
	{
		private IList<T> list;

		public SynchronizedList (IList<T> list)
		{
			this.list = list;
		}

		public int IndexOf (T item)
		{
			lock (list) {
				return list.IndexOf (item);
			}
		}

		public void Insert (int index, T item)
		{
			lock (list) {
				list.Insert (index, item);
			}
		}

		public void RemoveAt (int index)
		{
			lock (list) {
				list.RemoveAt (index);
			}
		}

		void ICollection<T>.Add (T item)
		{
			lock (list) {
				list.Add (item);
			}
		}

		void ICollection<T>.Clear ()
		{
			lock (list) {
				list.Clear ();
			}
		}

		bool ICollection<T>.Contains (T item)
		{
			lock (list) {
				return list.Contains (item);
			}
		}

		void ICollection<T>.CopyTo (T[] array, int arrayIndex)
		{
			lock (list) {
				list.CopyTo (array, arrayIndex);
			}
		}

		bool ICollection<T>.Remove (T item)
		{
			lock (list) {
				return list.Remove (item);
			}
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator ()
		{
			return list.GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return list.GetEnumerator ();
		}

		public T this[int index] {
			get {
				lock (list) {
					return list[index];
				}
			}
			set {
				lock (list) {
					list[index] = value;
				}
			}
		}

		int ICollection<T>.Count {
			get {
				lock (list) {
					return list.Count;
				}
			}
		}

		bool ICollection<T>.IsReadOnly {
			get { return list.IsReadOnly; }
		}
	}
}
