	public static int GetStatusID(this StatusFlags flag)
	{
		return
			Enum
				.GetValues(typeof(StatusFlags))
				.Cast<StatusFlags>()
				.Select((f, n) => new { f, n })
				.Where(fn => fn.f == flag)
				.Select(fn => fn.n)
				.DefaultIfEmpty(0)
				.First();
	}
