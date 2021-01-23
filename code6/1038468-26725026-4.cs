    public static string GetName<TEntity, TData>(this Expression<Func<TEntity, TData>> field)
    {
        var name = "";
        if (field.Body is MemberExpression)
        {
            var body = field.Body as MemberExpression;
            var ebody = body.Expression as MemberExpression;
            if (ebody != null)
            {
                name = ebody.Member.Name + ".";
            }
            name = name + body.Member.Name;
        }
        else if (field.Body is UnaryExpression)
        {
            var ubody = field.Body as UnaryExpression;
            var body = ubody.Operand as MemberExpression;
            var ebody = body.Expression as MemberExpression;
            if (ebody != null)
            {
                name = ebody.Member.Name + ".";
            }
            name = name + body.Member.Name;
        }
        else if (field.Body is ConstantExpression)
        {
            var cbody = field.Body as ConstantExpression;
            name = cbody.Value.ToString();
        }
        else
        {
            throw new InvalidOperationException(String.Format("{0} not supported.", field));
        }
        return name;
    }
