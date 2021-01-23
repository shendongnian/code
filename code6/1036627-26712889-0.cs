        public static Expression<Func<T, bool>> DynamicIntContains<T, TProperty>(string property, IEnumerable<TProperty> items, object source, PropertyInfo propertyInfo)
        {
            var pe = Expression.Parameter(typeof(T));
            var me = Expression.Property(pe, property.Singularise());
            var ce = Expression.Constant(propertyInfo.GetValue(source, null), typeof(List<int>));
            var convertExpression = Expression.Convert(me, typeof(int));
            var call = Expression.Call(ce, "Contains", new Type[] { }, convertExpression);
            return Expression.Lambda<Func<T, bool>>(call, pe);
        }
