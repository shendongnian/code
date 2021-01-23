    public static class Helper
    {
        public static U SafeCast<T, U>(this T obj, Expression<Func<T, object>> memberExpression, U defaultValue)
            where T : class
            where U : class
        {
            if (obj == null)
            {
                return defaultValue;
            }
    
            var me = memberExpression.Body as MemberExpression;
            if (me == null)
            {
                throw new ArgumentException("memberExpression must be MemberExpression");
            }
    
            // TODO : Check for fields, not only properties
            var memberValue = obj.GetType().GetProperty(me.Member.Name).GetValue(obj) as U;
            if (memberValue != null)
            {
                return memberValue;
            }
    
            return defaultValue;
        }
    }
