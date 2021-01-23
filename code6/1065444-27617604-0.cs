    class Program
    {
        static void Main(string[] args)
        {
            string path = GetPropertyName<Test>(x => x.Test2.Application.Id);
        }
        static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            return GetMemberExpressionPath(memberExpression);
        }
        static string GetMemberExpressionPath(MemberExpression exp)
        {
            string s = null;
            var rootExp = exp.Expression as MemberExpression;
            if (rootExp != null)
            {
                s = GetMemberExpressionPath(rootExp);
            }
            //var paramExp = exp.Expression as ParameterExpression;
            //if (paramExp != null)
            //{
            //    s = paramExp.Name;
            //}
            return (s != null ? s + "." : "") + exp.Member.Name;
        }
    }
