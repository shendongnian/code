        /// <summary>
        /// Build a lambda expression for a setter
        /// </summary>
        public static Action<T, U> GetSetter<T, U>(string propertyName)
        {
            // TODO: Maintain a dictionary mapping typeof(T)+property onto the 
            // resulting Action so this can be cached
            PropertyInfo property = typeof(T).GetProperty(propertyName);
            var setMethod = property.GetSetMethod();
            var parameterT = Expression.Parameter(typeof(T), "x");
            var parameterU = Expression.Parameter(typeof(U), "y");
            var newExpression =
                Expression.Lambda<Action<T, U>>(
                    Expression.Call(parameterT, setMethod, parameterU),
                    parameterT,
                    parameterU
                );
            return newExpression.Compile();
        }
