	public static class SplitEx
	{
		public static string[] SplitInline(this string text, char delimeter)
		{
			var results = text.Split(delimeter);
			return
				results
					.Take(1)
					.Concat(
						results
							.Skip(1)
							.SelectMany(x => new []
							{
								Convert.ToString(delimeter),
								x,
							}))
					.Where(x => !String.IsNullOrWhiteSpace(x))
					.ToArray();
		}
	}
