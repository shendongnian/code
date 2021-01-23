    private static object ExtractValue(Expression expression, object[] input, ReadOnlyCollection<ParameterExpression> parameters)
    {
        if (expression == null)
        {
            return null;
        }
    
        var ce = expression as ConstantExpression;
        if (ce != null)
        {
            return ce.Value;
        }
    
        var pe = expression as ParameterExpression;
        if (pe != null)
        {
            return input[parameters.IndexOf(pe)];
        }
    
        var ma = expression as MemberExpression;
        if (ma != null)
        {
            var se = ma.Expression;
            object val = null;
            if (se != null)
            {
                val = ExtractValue(se, input, parameters);
            }
    
            var fi = ma.Member as FieldInfo;
            if (fi != null)
            {
                return fi.GetValue(val);
            }
            else
            {
                var pi = ma.Member as PropertyInfo;
                if (pi != null)
                {
                    return pi.GetValue(val);
                }
            }
        }
    
        var mce = expression as MethodCallExpression;
        if (mce != null)
        {
            return mce.Method.Invoke(ExtractValue(mce.Object, input, parameters), mce.Arguments.Select(a => ExtractValue(a, input, parameters)).ToArray());
        }
    
        var sbe = expression as BinaryExpression;
        if (sbe != null)
        {
            var left = ExtractValue(sbe.Left, input, parameters);
            var right = ExtractValue(sbe.Right, input, parameters);
                    
            // TODO: check for other types and operands
    
            if (sbe.NodeType == ExpressionType.Add)
            {
                if (left is int && right is int)
                {
                    return (int) left + (int) right;
                }
            }
    
            throw new NotImplementedException();
        }
    
        var le = expression as LambdaExpression;
        if (le != null)
        {
            return ExtractValue(le.Body, input, le.Parameters);
        }
    
        // TODO: Check for other expression types
    
        var dynamicInvoke = Expression.Lambda(expression).Compile().DynamicInvoke();
        return dynamicInvoke;
    }
