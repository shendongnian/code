    public static void Assert(Expression<Func<bool>> expression)
    {
        if (!expression.Compile().Invoke())
        {
            throw new InvalidOperationException(String.Format("Assert: {0} may not be false!", expression.ToString()));
        }
    }
