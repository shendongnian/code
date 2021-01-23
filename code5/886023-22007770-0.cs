        public static Expression GetCondition<TParent, TChild, TChildKey>(
                              Expression<Func<TParent, TChild>> pe,
                              Expression<Func<TChild, TChildKey>> ce)
        {
            var test = Expression.Equal(pe.Body, Expression.Constant(null));
            ConstantExpression ifTrue;
            Type type = typeof(TChildKey);
            // check if it is a nullable type
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                ifTrue = Expression.Constant(default(TChildKey));
            }
            else
            {
                ifTrue = Expression.Constant(   Activator.CreateInstance<TChildKey>());
            }
            
            var ifFalse = Expression.Property(pe.Body, (ce.Body as MemberExpression).Member.Name);
            return Expression.Condition(test, ifFalse, ifFalse);
        }
