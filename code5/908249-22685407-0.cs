    public static Expression GetNavigationPropertyExpression(Expression parameter, int test, params string[] properties)
    {
        Expression resultExpression = null;
        Expression childParameter, navigationPropertyPredicate;
        Type childType = null;
        if (properties.Count() > 1)
        {
            //build path
            parameter = Expression.Property(parameter, properties[0]);
            var isCollection = typeof(IEnumerable).IsAssignableFrom(parameter.Type);
            //if it´s a collection we later need to use the predicate in the methodexpressioncall
            if (isCollection)
            {
                childType = parameter.Type.GetGenericArguments()[0];
                childParameter = Expression.Parameter(childType, childType.Name);
            }
            else
            {
                childParameter = parameter;
            }
            //skip current property and get navigation property expression recursivly
            var innerProperties = properties.Skip(1).ToArray();
            navigationPropertyPredicate = GetNavigationPropertyExpression(childParameter, test, innerProperties);
            if (isCollection)
            {
                //build methodexpressioncall
                var anyMethod = typeof(Enumerable).GetMethods().Single(m => m.Name == "Any" && m.GetParameters().Length == 2);
                anyMethod = anyMethod.MakeGenericMethod(childType);
                navigationPropertyPredicate = Expression.Call(anyMethod, parameter, navigationPropertyPredicate);
                resultExpression = MakeLambda(parameter, navigationPropertyPredicate);
            }
            else
            {
                resultExpression = navigationPropertyPredicate;
            }
        }
        else
        {
            //Formerly from ACLAttribute
            var childProperty = parameter.Type.GetProperty(properties[0]);
            var left = Expression.Property(parameter, childProperty);
            var right = Expression.Constant(test, typeof(int));
            navigationPropertyPredicate = Expression.Equal(left, right);
            resultExpression = MakeLambda(parameter, navigationPropertyPredicate);
        }
        return resultExpression;
    } 
 
    private static Expression MakeLambda(Expression parameter, Expression predicate)
    {
        var resultParameterVisitor = new ParameterVisitor();
        resultParameterVisitor.Visit(parameter);
        var resultParameter = resultParameterVisitor.Parameter;
        return Expression.Lambda(predicate, (ParameterExpression)resultParameter);
    }
    private class ParameterVisitor : ExpressionVisitor
    {
        public Expression Parameter
        {
            get;
            private set;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            Parameter = node;
            return node;
        }
    }
