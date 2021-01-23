    var value = Expression.Parameter(typeof(int));
    var meth = Expression.Lambda<Func<int, string>>(
      Expression.Switch(
        value,
        Expression.Call(value, typeof(object).GetMethod("ToString")),
        Expression.SwitchCase(Expression.Constant("Zero"), Expression.Constant(0, typeof(int))),
        Expression.SwitchCase(Expression.Constant("One"), Expression.Constant(1, typeof(int)))),
        value
      ).Compile();
    Console.WriteLine(meth(0)); // Zero
    Console.WriteLine(meth(1)); // One
    Console.WriteLine(meth(2)); // 2
