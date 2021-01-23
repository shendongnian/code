    public class EfUtil
    {
        public static T ResultOf<T>(T value)
        {
            return value;
        }
    }
    //Note this could probably use a better name
    public static IQueryable<T> EvaluateResults<T>(this IQueryable<T> query)
    {
        return query.Provider.CreateQuery<T>(
            new ExpressionEvaluator().Visit(query.Expression));
    }
    internal class ExpressionEvaluator : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.Name == "ResultOf" && m.Method.DeclaringType == typeof(EfUtil))
            {
                Expression target = m.Arguments[0];
                object result = Expression.Lambda(target)
                    .Compile()
                    .DynamicInvoke();
                return Expression.Constant(result, target.Type);
            }
            else
                return base.VisitMethodCall(m);
        }
    }
