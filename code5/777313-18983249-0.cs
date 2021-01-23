    public void getNewClass(Object testObj, params MemberExpression Fields[])
    {
        foreach(MemberExpression field in Fields)
        {
            // Get the name
            var name = field.Member.Name;
            // get the value
            var member= Expression.Convert(field, typeof(object));
            var lambda= Expression.Lambda<Func<object>>(member);
            var fnc= lambda.Compile();
            var value = fnc();
        }
    }
