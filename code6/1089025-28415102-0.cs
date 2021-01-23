    public static unsafe int CalculateTotalBytesForUTF8Conversion(
        string stringToCount,
        int startIndex,
        int endIndex)
    {
		// Fix the string in memory so we can grab a pointer to its location.
		fixed (char* substring = stringToCount)
		{
        	// Move the pointer to the start of the string.
        	substring += startIndex;
        	return Encoding.UTF8.GetByteCount(substring, endIndex - startIndex);
    	}
    }
