    var binder = Binder.GetMember(
        CSharpBinderFlags.None, 
        "Value", 
        typeof(Program), // or this.GetType() 
        new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
    var par = Expression.Parameter(typeof(object));
    Func<dynamic, dynamic> f = Expression.Lambda<Func<dynamic, dynamic>>(
        Expression.Dynamic(binder, typeof(object), par), 
        par)
        .Compile();
    dynamic obj = new ExpandoObject();
    obj.Value = "Hello";
    object value = f(obj); // Hello
