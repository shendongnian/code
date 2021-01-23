		public IEnumerable<List<T>> ColumnRange(int left, int right)
		{
			using (var mapenum = map.GetEnumerator())
			{
				bool finished = mapenum.MoveNext();
				while (!finished && mapenum.Current.Key < left)
					finished = mapenum.MoveNext();
				while (!finished && mapenum.Current.Key <= right)
				{
					yield return mapenum.Current.Value;
					finished = mapenum.MoveNext();
				}
				
			}
		}
