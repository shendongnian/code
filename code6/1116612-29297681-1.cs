    Func<Foo, int> getter = expression.Compile();
    var parameter = Expression.Parameter(expression.ReturnType);
    Action<Foo, int> setter = Expression.Lambda<Action<Foo, int>>(
        Expression.Assign(expression.Body, parameter ), 
        new[] { expression.Parameters[0], parameter }).Compile();
    Foo foo = new Foo();
    setter(foo, 5); // Example of use of the setter
    int value = getter(foo); // Example of use of the getter
