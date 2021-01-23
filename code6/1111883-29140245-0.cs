    public Helper()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ISomething)));
        foreach (var type in types)
        {
            var data = Expression.Parameter(typeof(string), "data");
            var call = Expression.Call(typeof(Helper), "DoSomething", new Type[] { type }, data);
            var lambda = Expression.Lambda(call, data);
    
            Actions[type.Name] = (Func<string, string>)lambda.Compile();
        }
    }
