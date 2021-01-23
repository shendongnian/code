    public static class EnumUtilities
    {
        public static IEnumerable<Tuple<TEnum, object>> GetTuples<TEnum>() where TEnum :    struct, IConvertible
        {
		    if (!typeof(TEnum).IsEnum)
			   throw new Exception("wrong!");
	
            return GetValues<TEnum>().Select(x => new Tuple<TEnum, object>(x, Convert.ChangeType(x, x.GetTypeCode())));
        }
        public static IEnumerable<T> GetValues<T>()
        {
             return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
