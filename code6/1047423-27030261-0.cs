    public static void SetValue<TField>(Expression<Func<TField>> field, TField value)
    {
        var expression = Expression.Lambda<Action>(
            Expression.Assign(field.Body, Expression.Constant(value)));
        expression.Compile()();
    }
