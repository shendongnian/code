    private static MemoryCache _instance = MemoryCache.Default;
    public static IEnumerable<MyDto> GetDtos()
	{
		var result = _instance.Get(SOME_NAME);
		if (result == null)
			result = InitializeCache();
		return result;
	}
