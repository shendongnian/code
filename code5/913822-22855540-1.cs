        public Func<Object, Object> CreateFunc(object sampleValue)
        {
            var parameter = Expression.Parameter(typeof(object), "x");
            var conversion = Expression.Convert(parameter, sampleValue.GetType());
            var property = Expression.Property(conversion, "Name");
            return Expression.Lambda<Func<object, object>>(property, parameter)
                             .Compile();
        }
