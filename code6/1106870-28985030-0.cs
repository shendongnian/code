    public static void Assert(Func<bool> expression)
    {
        if (!expression())
        {
            throw new InvalidOperationException("Assert: " + expression.ToString() + " may not be false!");
        }
    }
