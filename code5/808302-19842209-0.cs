    public Expression<Func<ElementNode, bool>> CreateEqualNameExpression(string match)
    {
        var parm = Expression.Parameter(typeof(ElementNode), "element");
        var expr = Expression.Property(parm, "Name");
        var var1 = Expression.Variable(typeof(string), "elementName");
        var assign = Expression.Assign(var1, expr);
        var parm2 = Expression.Constant(match, typeof(string));
        var exp = Expression.Equal(var1, parm2);
        return Expression.Lambda<Func<ElementNode, bool>>(
            Expression.Block(new[] { var1 }, assign, exp),
            parm);
    }
