    public static IEnumerable<Enum> ToEnumerable(this Enum input)
    {
        foreach (Enum value in Enum.GetValues(input.GetType()))
            if (input.HasFlag(value) && Convert.ToInt64(value) != 0)
                yield return value;
    }
	
