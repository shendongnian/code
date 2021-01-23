    public static void Assert(Expression<Func<bool>> expression)
    {
        if (!expression.Compile().Invoke())
        {
            throw new InvalidOperationException("Assert: " + expression.ToString() + " may not be false!");
        }
    }
