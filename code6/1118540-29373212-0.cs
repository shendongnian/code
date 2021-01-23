    MethodInfo ConsoleWriteLine3 = typeof(Console).GetMethod(
        "WriteLine", new Type[] { typeof(string), typeof(object), typeof(object) });
    
    …
    
    Expression.Call(
        null, ConsoleWriteLine3,
        Expression.Constant("Iteration {0}, Value = {1}"),
        Expression.Convert(IteratorInt, typeof(object)),
        Expression.Convert(TempInteger, typeof(object)))
