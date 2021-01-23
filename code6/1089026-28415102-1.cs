    public static unsafe int CalculateTotalBytesForUTF8Conversion(
        string stringToCount,
        int startIndex,
        int endIndex)
    {
		// Fix the string in memory so we can grab a pointer to its location.
		fixed (char* stringStart = stringToCount)
		{
        	// Get a pointer to the start of the substring.
        	char* substring = stringStart + startIndex;
        	return Encoding.UTF8.GetByteCount(substring, endIndex - startIndex);
    	}
    }
