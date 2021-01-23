        public static LambdaExpression GetFieldOrPropertyLambda(PropertyOrFieldAccessType accessType, Type objectType, string fieldOrPropertyExpression)
        {
            ParameterExpression initialObjectParameterExpression = Expression.Parameter(objectType, objectType.Name);
            
            Expression pathExpression = initialObjectParameterExpression;
            foreach (string property in fieldOrPropertyExpression.Split('.'))
                pathExpression = Expression.PropertyOrField(pathExpression, property);
            LambdaExpression resultExpression;
            switch (accessType)
            {
                case PropertyOrFieldAccessType.Get:
                    
                    resultExpression = Expression.Lambda(
                        getGenericGetFunction(objectType, pathExpression.Type), // This makes it work for valueTypes.
                        pathExpression,
                        initialObjectParameterExpression);
                    break;
                case PropertyOrFieldAccessType.Set:
                    
                    ParameterExpression assignParameterExpression = Expression.Parameter(pathExpression.Type);
                    BinaryExpression assginExpression = Expression.Assign(pathExpression, assignParameterExpression);
                    
                    resultExpression = Expression.Lambda(
                        getGenericSetAction(objectType, assginExpression.Type), // This makes it work for valueTypes.
                        assginExpression,
                        initialObjectParameterExpression,
                        assignParameterExpression);
                    break;
                default: throw new NotImplementedException();
            }
            return resultExpression;
        }
        private static Type getGenericGetFunction(Type param1, Type param2)
        {
            return typeof(Func<,>).MakeGenericType(param1, param2);
        }
        private static Type getGenericSetAction(Type param1, Type param2)
        {
            return typeof(Action<,>).MakeGenericType(param1, param2);
        }
