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
		public static string[] SplitInline(this string text, string delimeters)
		{
			if (String.IsNullOrEmpty(delimeters))
			{
				return new [] { text };
			}
			else
			{
				var head = delimeters[0];
				var tail = new string(delimeters.Skip(1).ToArray());
				return
					text
						.SplitInline(head)
						.SelectMany(x => x.SplitInline(tail))
						.ToArray();
			}
		}
	}
