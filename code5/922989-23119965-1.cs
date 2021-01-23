    public static class SessionExtensions
    {
        private static int __x = 0;
        public static T ExecuteExpression<T>(this Session session, string expressionCode)
        {
            var x = __x++;
            session.Execute(String.Format(@"Function _SessionExtensions_ExecuteExpression_{1} As Object
                Return {0}
            End Function", expressionCode, x));
            return (T)session.Execute(String.Format("_SessionExtensions_ExecuteExpression_{0}", x));
        }
    }
