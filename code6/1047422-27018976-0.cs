        public void SetValue<TField>(Expression<Func<TField>> field, object value)
        {
            MemberExpression memberExpression = field.Body as MemberExpression;
            var objectMember = Expression.Convert(memberExpression.Expression, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            var obj = getter();
            (memberExpression.Member as FieldInfo).SetValue(obj, value);        
        }
