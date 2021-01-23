    public static IEnumerable<Tuple<TEnum, TBase>> GetTuples<TEnum, TBase>()
           where TEnum : struct, IConvertible
	{
        Type tEnumType = typeof(TEnum);
		if (!tEnumType.IsEnum || Enum.GetUnderlyingType(tEnumType) != typeof(TBase))
		{
			throw new ArgumentException("Invalid type specified.");
		}
		return GetValues<TEnum>().Select(x => new Tuple<TEnum, TBase>(x, (TBase)Convert.ChangeType(x, typeof(TBase))));
	}
