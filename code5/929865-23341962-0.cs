    public static void Test<TProperty>(Expression<Func<Model, TProperty>> strongTyped, Expression<Func<Model, object>> weakTyped)
    {
        var expr = (UnaryExpression)weakTyped.Body;
        Console.WriteLine("Weak Typed method: {0}", expr.Method);
        Console.WriteLine("Strong Typed: {0}", strongTyped);
        Console.WriteLine("Weak Typed: {0}", weakTyped);
    }
    public static void TestFloat<TProperty>(Expression<Func<Model, TProperty>> strongTyped, Expression<Func<Model, decimal>> weakTyped)
    {
        var expr = (UnaryExpression) weakTyped.Body;
        Console.WriteLine("Weak Typed method: {0}", expr.Method);
        Console.WriteLine("Strong Typed: {0}", strongTyped);
        Console.WriteLine("Weak Typed: {0}", weakTyped);
    }
