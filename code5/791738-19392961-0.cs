    public class ConcatEnum : IEnumerator
	{
		public List<String> _values;
		// Enumerators are positioned before the first element 
		// until the first MoveNext() call. 
		int position1 = 0;
		int position2 = 0;
		public ConcatEnum(List<String> list)
		{
			_values = list;
		}
		public bool MoveNext()
		{
			position2 = Math.Max(position2 + 1, position1 + 1);
			if (position2 > _values.Count - 1){
				position1++;
				position2 = position1 + 1;
			}
			return position1 < _values.Count - 1;
		}
		public void Reset()
		{
			position1 = 0;
			position2 = 0;
		}
		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}
		public String Current
		{
			get
			{
				try
				{
					return _values[position1] + _values[position2];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}
		public IEnumerator GetEnumerator()
		{
			this.Reset();
			while (this.MoveNext())
			{
				yield return Current;
			}
		}
	}
