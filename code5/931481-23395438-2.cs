    public static IQueryable<ExtendedMyClass> Extend(
        IQueryable<MyClass> myQueryable,
        Dictionary<string, Expression<Func<MyClass, bool>>> extraFields)
    {
        Func<Expression<Func<MyClass, bool>>, MyClass, bool> invoke =
            LinqKit.Extensions.Invoke;
        var parameter = Expression.Parameter(typeof(MyClass));
        var extraFieldsExpression =
            Expression.Lambda<Func<MyClass, StringAndBool[]>>(
                Expression.NewArrayInit(
                    typeof(StringAndBool),
                    extraFields.Select(
                        field => Expression.MemberInit(
                            Expression.New(typeof(StringAndBool)),
                            new MemberBinding[]
                            {
                                Expression.Bind(
                                    typeof(StringAndBool).GetProperty("FieldName"),
                                    Expression.Constant(field.Key)),
                                Expression.Bind(
                                    typeof(StringAndBool).GetProperty("IsTrue"),
                                    Expression.Call(
                                        invoke.Method,
                                        Expression.Constant(field.Value),
                                        parameter))
                            }))),
                parameter);
        Expression<Func<MyClass, ExtendedMyClass>> selectExpression =
            x => new ExtendedMyClass
            {
                MyObject = x,
                ExtraFieldValues = extraFieldsExpression.Invoke(x)
            };
        return myQueryable.Select(selectExpression.Expand());
    }
