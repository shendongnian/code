	public static class ChoiceExtensions
	{
		public static void Match<T1, T2>(this IEnumerable<Choice<T1, T2>> seq, Action<T1> onChoice1Of2, Action<T2> onChoice2Of2)
		{
			foreach (var choice in seq)
			{
				choice.Match(onChoice1Of2, onChoice2Of2);
			}
		}
	}
