        static Delegate CreateGenericGetterDelegate<TClass>(PropertyInfo propertyInfo)
        {
            var method = typeof(Cache).GetMethod("CreateTypedGetterDelegate"); 
            MethodInfo generic = method.MakeGenericMethod(new Type[] { typeof(TClass), propertyInfo.PropertyType });
            return (Delegate) generic.Invoke(new object(), new object[] { propertyInfo });
        }
        public static Delegate CreateTypedGetterDelegate<TClass, TProp>(PropertyInfo propertyInfo)
        {
            if (typeof(TClass) != propertyInfo.DeclaringType)
            {
                throw new ArgumentException();
            }
            var instance = Expression.Parameter(propertyInfo.DeclaringType);
            var property = Expression.Property(instance, propertyInfo);
            if (typeof(TProp).IsValueType)
            {
                return (Func<TClass, TProp>)Expression.Lambda(property, instance).Compile();
            }
            else
            {
                return (Func<TClass, TProp>)Expression.Lambda(Expression.TypeAs(property, typeof(TProp)), instance).Compile();
            }
        }
