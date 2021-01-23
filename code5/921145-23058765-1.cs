    /// <summary>
    /// Converts the string to a specified enumeration.
    /// A value specifies whether the operation is case-insensitive.
    /// </summary>
    /// <typeparam name="TEnum">The type of System.Enum to parse as.</typeparam>
    /// <param name="value">The System.String value.</param>
    /// <param name="ignoreCase"><c>true</c> to ignore case; <c>false</c> to regard case.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> does not map to one of the named constants defined in <typeparamref name="TEnum"/>.</exception>
    public static TEnum ParseAs<TEnum>(this String value, bool ignoreCase)
        where TEnum : struct
    {
        return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
    }
