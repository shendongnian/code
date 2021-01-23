    public class DataBuilder<T>
    {
        public readonly T data;
        public DataBuilder()
        {
            data = Activator.CreateInstance<T>();
        }
        public DataBuilder(T data)
        {
            this.data = data;
        }
        public DataBuilder<T> SetValue<T2>(Expression<Func<T, T2>> expression, T2 value)
        {
            var mExpr = GetMemberExpression(expression);
            
            var obj = Recurse(mExpr);
            var p = (PropertyInfo)mExpr.Member;
            p.SetValue(obj, value); 
            return this;
        }
        public T Build()
        {
            return data;
        }
        public object Recurse(MemberExpression expr)
        {
            if (expr.Expression.Type != typeof(T))
            {
                var pExpr = GetMemberExpression(expr.Expression);
                var parent = Recurse(pExpr);
                var pInfo = (PropertyInfo) pExpr.Member;
                var obj = pInfo.GetValue(parent);
                if (obj == null)
                {
                    obj = Activator.CreateInstance(pInfo.PropertyType);
                    pInfo.SetValue(parent, obj);
                }
                return obj;
            }
            return data;
        }
        private static MemberExpression GetMemberExpression(Expression expr)
        {
            var member = expr as MemberExpression;
            var unary = expr as UnaryExpression;
            return member ?? (unary != null ? unary.Operand as MemberExpression : null);
        }
        private static MemberExpression GetMemberExpression<T2>(Expression<Func<T, T2>> expr)
        {
            return GetMemberExpression(expr.Body);
        }
    }
