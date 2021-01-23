    public void Match<TSource, TType>(TSource dest, Expression<Func<TSource, TType>> original, TType updateValue)
    {
        var originalValue = original.Compile()(dest);
        if (!updateValue.Equals(originalValue))
        {
            // get prop name from expression
            var prop = original.GetMemberInfo().Name;
            typeof(TSource).GetProperty(prop).SetValue(dest, updateValue);
        }
    }
    //helper class to get propinfo from expression
    public static class ExpressionExtensions
    {
        public static MemberInfo GetMemberInfo(this Expression expression)
        {
            var lambda = (LambdaExpression) expression;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression) lambda.Body;
                memberExpression = (MemberExpression) unaryExpression.Operand;
            }
            else
                memberExpression = (MemberExpression) lambda.Body;
            return memberExpression.Member;
        }
    }
