    [Fact]
    public void CreateExpression()
    {
        Type argType = typeof (MyClass);
        string propertyName = "Name";
        ParameterExpression paramExpression = Expression.Parameter(argType, "item");
        //Create "item.Name" and "item.GetType()" expressions
        var propertyAccessExpression = Expression.Property(paramExpression, propertyName); 
        var getTypeExpression = Expression.Call(paramExpression, "GetType", Type.EmptyTypes);
        Type anonType = CreateAnonymousType<String, Type>("SelectedProp", "TypeOfProp");
        //"SelectProp = item.name"
        MemberBinding assignment1 = Expression.Bind(anonType.GetField("SelectedProp"), propertyAccessExpression);
        //"TypeOfProp = item.GetType()"
        MemberBinding assignment2 = Expression.Bind(anonType.GetField("TypeOfProp"), getTypeExpression);
        //"new AnonymousType()"
        var creationExpression = Expression.New(anonType.GetConstructor(Type.EmptyTypes));
        //"new AnonymousType() { SelectProp = item.name, TypeOfProp = item.GetType() }"
        var initialization = Expression.MemberInit(creationExpression, assignment1, assignment2);
        //"item => new AnonymousType() { SelectProp = item.name, TypeOfProp = item.GetType() }"
        Expression expression = Expression.Lambda(initialization, paramExpression);
    }
