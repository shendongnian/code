    public static byte[] Size<T>() where T : HashAlgorithm, new()
    {
    	using (var hash = new T())
    	{
    		return hash.ComputeHash(Encoding.Default.GetBytes("hello"));
    	}
    }
