    var values = new List<object>();
    foreach(var arg in body.Arguments)
    {
        var value = Expression.Lambda(argument).Compile().DynamicInvoke();
        values.Add(value);
    }
    this.ArgValues = values.ToArray();
