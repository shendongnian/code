    /// <summary>
    /// Get c = a mod (b) with c in [0, b[ like the mathematical definition
    /// </summary>
    public static int MathMod(int a, int b)
    {
        int c = ((a % b) + b) % b;
        return c;
    }
    public static IEnumerable<T> ShiftRight<T>(IList<T> values, int shift)
    {
        for (int index = 0; index < values.Count; index++)
        {
            yield return values[MathMod(index - shift, values.Count)];
        }
    }
