    public static string GetAttributeFormatedString<TModel, TMember>(this TModel model, Expression<Func<TModel, TMember>> memberSelector)
    {
        var selectorBody = memberSelector.Body;
        if (selectorBody.NodeType != ExpressionType.MemberAccess)
        {
            throw new ArgumentException("Nope dude, not this time", "memberSelector");
        }
        var attribute = ((MemberExpression) selectorBody).Member
            .GetCustomAttributes(typeof(DisplayFormatAttribute), true)
            .OfType<DisplayFormatAttribute>()
            .FirstOrDefault();
        if (attribute == null)
        {
            throw new InvalidOperationException("Attribute, dude");
        }
        var format = attribute.DataFormatString;
        var result = string.Format(format, memberSelector.Compile().Invoke(model));
        return result;
    }
