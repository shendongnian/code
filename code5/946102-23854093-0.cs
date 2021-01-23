	Func<IEnumerable<string>, IEnumerable<char>, IEnumerable<string>> split = null;
	split = (ss, cs) =>
	{
		if (!cs.Any())
		{
			return ss;
		}
		else
		{
			var c = cs.First();
			return ss.SelectMany(s0 =>
			{
				var parts = s0.Split(c);
				return split(
					parts
						.Take(1)
						.Concat(
							parts
								.Skip(1)
								.SelectMany(p => new [] { new string(c, 1), p })),
					cs.Skip(1));
			})
			.Where(s0 => !String.IsNullOrWhiteSpace(s0));
		}
	};
