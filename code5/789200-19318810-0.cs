     public static Expression<Func<T, bool>> ContainsExp<T>(string propertyName, string contains)
            {
    
                //first, get the type of your property
                var propertyType = typeof(T).GetProperty(propertyName).PropertyType;
                //no change
                var parameterExp = Expression.Parameter(typeof (T), "type");
                Expression propertyExp = Expression.Property(parameterExp, propertyName);
                //if property's type is int
                if (propertyType == typeof (int))
                {
                    //convert your Expression to a nullable double (or nullable decimal),
                    //so that you can use SqlFunctions.StringConvert
                    propertyExp = Expression.Convert(propertyExp, typeof (double?));
                    //get the SqlFunctions.StringConvert method for nullable double
                    var stringConvertMethod = typeof (SqlFunctions).GetMethod("StringConvert", new[] {typeof (double?)});
                    //call StringConvert on your converted expression
                    propertyExp = Expression.Call(stringConvertMethod , propertyExp);
                }
                //no change
                var method = typeof (string).GetMethod("Contains", new[] {typeof (string)});
    
    
                var someValue = Expression.Constant(contains, typeof (string));
                var containsMethodExp = Expression.Call(propertyExp, method, someValue);
    
                return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
    
            }
