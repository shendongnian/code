    /// <summary>
    /// Does nothing, just avoids "parameter/variable is not used" warnings.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="value">The value.</param>
    [Conditional("NEVER")]
    public static void DummyUsage<T>(this T value)
    {         
        // just dummy code
        if (value is object)
        {
            return;
        }
    }
