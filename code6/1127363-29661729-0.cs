	public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T>
	{
		return (min == null || value.CompareTo((T)min) >= 0)
            && (max == null || value.CompareTo((T)max) <= 0);
	}
	public static bool IsBetween<T>(this T value, T? min, T? max) where T : struct, IComparable<T>
	{
		return (min == null || value.CompareTo((T)min) >= 0)
            && (max == null || value.CompareTo((T)max) <= 0);
	}
