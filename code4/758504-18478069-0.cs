	public static IEnumerable<string> AppendSuffix(
		this string @this, string dictionary)
	{
		return dictionary.Select(x => @this + x);
	}
	
	public static IEnumerable<string> AppendSuffix(
		this string @this, string dictionary, int levels)
	{
		var r = @this.AppendSuffix(dictionary);
		if (levels > 1)
		{
			r = r.SelectMany(x => x.AppendSuffix(dictionary, levels - 1));
		}
		return r;
	}
	public static IEnumerable<string> AppendSuffix(
		this IEnumerable<string> @this, string dictionary)
	{
		return @this.SelectMany(x => x.AppendSuffix(dictionary));
	}
	
	public static IEnumerable<string> AppendSuffix(
		this IEnumerable<string> @this, string dictionary, int levels)
	{
		var r = @this.AppendSuffix(dictionary);
		if (levels > 1)
		{
			r = r.SelectMany(x => x.AppendSuffix(dictionary, levels - 1));
		}
		return r;
	}
