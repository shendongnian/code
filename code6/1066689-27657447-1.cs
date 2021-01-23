    public static string ToFlags<T>(this T val)
        where T : struct
    {
        return string.Join(",", Enum.GetValues(typeof(T))
                     .Cast<T>()
                     .Select(enumEntry => ((int)(object)enumEntry & (int)(object)val) > 0
                                 ? enumEntry.ToString() : "")
                     .Where(f => !string.IsNullOrWhiteSpace(f)));
    }
