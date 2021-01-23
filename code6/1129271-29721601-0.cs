    // note the AsQueryable! Otherwise there is no
    // Expression tree!
    var words = new List<string>() { "an", "apple", "a", "day" }.AsQueryable();
    // Note that even IQueryable<string> query = words; 
    // is a perfectly good query without a projection!
    // The projection if not present is implicit, the
    // whole object.
    var query = from word in words
                select word;
    var exp = query.Expression;
    var methodCallExpression = exp as MethodCallExpression;
    if (methodCallExpression != null)
    {
        MethodInfo method = methodCallExpression.Method;
        if (method.DeclaringType == typeof(Queryable) && method.Name == "Select")
        {
            var source = methodCallExpression.Arguments[0];
            var selector = methodCallExpression.Arguments[1];
                    
            // The selector parameter passed to Select is an
            // Expression.Quote(subexpression),
            // where subexpression is the lambda expression
            // word => word here
            if (selector.NodeType != ExpressionType.Quote)
            {
                throw new NotSupportedException();
            }
            UnaryExpression unary = (UnaryExpression)selector;
            Expression operand = unary.Operand;
            if (operand.NodeType != ExpressionType.Lambda)
            {
                throw new NotSupportedException();
            }
            LambdaExpression lambda = (LambdaExpression)operand;
            // This is the "thing" that returns the result
            Expression body = lambda.Body; 
        }
    }
