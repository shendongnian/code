    public static class PropertyPathHelper
    {
        public static T GetValue<T>(object instance, string propPath)
        {
            Delegate runtimeDelegate;
    
            System.Linq.Expressions.ParameterExpression instanceParameter =
                System.Linq.Expressions.Expression.Parameter(instance.GetType(), "p");
    
            string[] properties = propPath.Split('.');
    
            System.Linq.Expressions.MemberExpression currentExpression =
                System.Linq.Expressions.Expression.PropertyOrField(instanceParameter, properties[0]);
    
            System.Linq.Expressions.LambdaExpression lambdaExpression =
                System.Linq.Expressions.Expression.Lambda(currentExpression, instanceParameter);
    
            for (int i = 1; i < properties.Length; i++)
            {
                currentExpression = System.Linq.Expressions.Expression.PropertyOrField(lambdaExpression.Body, properties[i]);
                lambdaExpression = System.Linq.Expressions.Expression.Lambda(currentExpression, instanceParameter);
            }
    
            runtimeDelegate = lambdaExpression.Compile();
    
            return (T)runtimeDelegate.DynamicInvoke(instance);
        }
    }
