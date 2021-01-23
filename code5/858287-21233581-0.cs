    var item = new MyType() { Name = "My name" };
    var pi = t.GetProperty("Name");
    ParameterExpression pe = Expression.Parameter(typeof(MyType), "x");
    ConstantExpression ce = Expression.Constant(typeof(MyType), "item");
    MemberExpression me = Expression.Property(ce, pi);
    var exp = Expression.Lambda(me, pe);
