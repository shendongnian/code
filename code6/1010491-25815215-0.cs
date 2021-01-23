    var b = test.GetType().GetInterfaces().FirstOrDefault(
        x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IProvider<,>));
    if(b != null)
    {
        var ofWhat = b.GetGenericArguments(); // [Input, Output]
        // ...
    }
