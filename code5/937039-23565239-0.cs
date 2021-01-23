	public class MyCollection<T> : IEnumerable<T>
	{
		private T Head;
		private MyCollection<T> Tail;
		private bool IsEmpty;
		private class ThisEnumerator : IEnumerator<T>
		{
			public ThisEnumerator(MyCollection<T> toIterate)
			{
				_innerCurrent = toIterate;
			}
			private MyCollection<T> _innerCurrent;
			private bool _hasMoved = false;
			public T Current
			{
				get
				{
					return _innerCurrent.Head;
				}
			}
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}
			public void Dispose()
			{
				_innerCurrent = null;
			}
			public bool MoveNext()
			{
				if (_hasMoved)
				{
					_innerCurrent = _innerCurrent.Tail;
				}
				else
				{
					_hasMoved = true;
				}
				return !_innerCurrent.IsEmpty;
			}
			public void Reset()
			{
				throw new NotSupportedException();
			}
		}
		public IEnumerator<T> GetEnumerator()
		{
			return new ThisEnumerator(this);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
