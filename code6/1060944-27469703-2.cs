	public static class ChoiceExtensions
	{
        // You need this method, because code 'select result' is a LINQ expression and it returns IEnumerable
		public static void Match<T1, T2>(this IEnumerable<Choice<T1, T2>> seq, Action<T1> onChoice1Of2, Action<T2> onChoice2Of2)
		{
			foreach (var choice in seq)
			{
				choice.Match(onChoice1Of2, onChoice2Of2);
			}
		}
        // This method will help with the complex matching
		public static Choice<T1, T2> Flat<T1, T2>(this Choice<Choice<T1, T2>, T2> choice)
		{
			Choice<T1, T2> result = null;
			choice.Match(
				t1 => result = t1,
				t2 => result = new Choice2Of2<T1, T2>(t2));
			return result;
		}
	}
