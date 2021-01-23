    public static void WriteCompressed<T>(this T[] towrite, Stream output) where T : struct, IConvertible
    {
    	if (!typeof(T).IsEnum)
    	{
    		throw new ArgumentException("T must be an enumerated type");
    	}
    	//.... Function Code ...
    }
