	// Make IEnumerable
	public abstract class Choice<T1, T2> : IEnumerable<Choice<T1, T2>>
	{
		IEnumerator<Choice<T1, T2>> IEnumerable<Choice<T1, T2>>.GetEnumerator()
		{
			yield return this;
		}
		public IEnumerator GetEnumerator()
		{
			yield return this;
		}
		public static implicit operator T1(Choice<T1, T2> c)
		{
			T1 val;
			c.MatchChoice1Of2(out val);
			return val;
		}
		public static implicit operator T2(Choice<T1, T2> c)
		{
			T2 val;
			c.MatchChoice2Of2(out val);
			return val;
		}
		
        // Continue Choice class
    }
