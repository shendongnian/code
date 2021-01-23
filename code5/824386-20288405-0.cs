    // System.Convert
    /// <summary>Converts the specified string representation of a number to an equivalent 32-bit signed integer.</summary>
    /// <returns>A 32-bit signed integer that is equivalent to the number in <paramref name="value" />, or 0 (zero) if <paramref name="value" /> is null.</returns>
    /// <param name="value">A string that contains the number to convert. </param>
    /// <exception cref="T:System.FormatException">
    /// <paramref name="value" /> does not consist of an optional sign followed by a sequence of digits (0 through 9). </exception>
    /// <exception cref="T:System.OverflowException">
    /// <paramref name="value" /> represents a number that is less than <see cref="F:System.Int32.MinValue" /> or greater than <see cref="F:System.Int32.MaxValue" />. </exception>
    /// <filterpriority>1</filterpriority>
    [__DynamicallyInvokable]
    public static int ToInt32(string value)
    {
    	if (value == null)
    	{
    		return 0;
    	}
    	return int.Parse(value, CultureInfo.CurrentCulture);
    }
