	// Implement IEnumerable to deal with LINQ
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
        // These two methods work with your Devide function
        // I think, it is good to throw an exception here, if c is not a choice of 1
		public static implicit operator T1(Choice<T1, T2> c)
		{
			T1 val;
			c.MatchChoice1Of2(out val);
			return val;
		}
        // And you can add exception here too
		public static implicit operator T2(Choice<T1, T2> c)
		{
			T2 val;
			c.MatchChoice2Of2(out val);
			return val;
		}
        // Your Match method returns void, it is not good in functional programming,
        // because, whole purpose of the method returning void is the change state,
        // and in FP state is immutable
        // That's why I've created PureMatch method for you
		public Choice<T1Out, T2Out> PureMatch<T1Out, T2Out>(Func<T1, T1Out> onChoice1Of2, Func<T2, T2Out> onChoice2Of2)
		{
			Choice<T1Out, T2Out> result = null;
			Match(
				t1 => result = new Choice1Of2<T1Out, T2Out>(onChoice1Of2(t1)),
				t2 => result = new Choice2Of2<T1Out, T2Out>(onChoice2Of2(t2)));
			return result;
		}
		
        // Continue Choice class
    }
