        public static Action<T, object> GetSetter<T>(T obj, string propertyName)
        {
            ParameterExpression targetExpr = Expression.Parameter(obj.GetType(), "Target");
            MemberExpression propExpr = Expression.Property(targetExpr, propertyName);
            ParameterExpression valueExpr = Expression.Parameter(typeof(object), "value");
            MethodCallExpression convertExpr = Expression.Call(typeof(Convert), "ChangeType", null, valueExpr, Expression.Constant(propExpr.Type));
            UnaryExpression valueCast = Expression.Convert(convertExpr, propExpr.Type);
            BinaryExpression assignExpr = Expression.Assign(propExpr, valueCast);
            return Expression.Lambda<Action<T, object>>(assignExpr, targetExpr, valueExpr).Compile();
        }
        private static Func<T, object> GetGetter<T>(T obj, string propertyName)
        {
            ParameterExpression arg = Expression.Parameter(obj.GetType(), "x");
            MemberExpression expression = Expression.Property(arg, propertyName);
            UnaryExpression conversion = Expression.Convert(expression, typeof(object));
            return Expression.Lambda<Func<T, object>>(conversion, arg).Compile();
        }
