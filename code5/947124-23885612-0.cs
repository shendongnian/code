	public class NdbScanTableTuple<TKey,TRow> : IEnumerable<TRow>
	{
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		
		public IEnumerator<TRow> GetEnumerator()
		{
			return new Enumerator<TRow>();
		}
		
		private class Enumerator<T> : IEnumerator<T>
		{
			object IEnumerator.Current { get { return this.Current; } }
			public T Current { get { return tmpRes; } }
			
			public void Dispose()
			{
				yieldTransaction.Close();
			}
			
			public bool MoveNext()
			{
			}
			
			public void Reset()
			{
			}
		}
	}
