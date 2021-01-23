    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> BaseAnd<T>() { return f => true; }
        public static Expression<Func<T, bool>> BaseOr<T>() { return f => false; }
        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var secondBody = expr2.Body.Replace(expr2.Parameters[0], expr1.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, secondBody), expr1.Parameters);
        }
        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var secondBody = expr2.Body.Replace(expr2.Parameters[0], expr1.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, secondBody), expr1.Parameters);
        }
        public static Expression Replace(this Expression expression,
        Expression searchEx, Expression replaceEx)
        {
            return new ReplaceVisitor(searchEx, replaceEx).Visit(expression);
        }
        public static Expression<Func<T, bool>> CombineOrPreicatesWithAndPredicates<T>(this Expression<Func<T, bool>> combinedPredicate,
            Expression<Func<T, bool>> andPredicate, Expression<Func<T, bool>> orPredicate)
        {
            combinedPredicate = combinedPredicate ?? BaseAnd<T>();
            if (andPredicate != null && orPredicate!=null)
            {
                andPredicate = andPredicate.And(orPredicate);
                combinedPredicate = combinedPredicate.And(andPredicate);
            }
            else if (orPredicate!=null)
            {
                combinedPredicate = combinedPredicate.And(orPredicate);
            }
            else
            {
                combinedPredicate = combinedPredicate.And(andPredicate);
            }
            return combinedPredicate;
        }
        public static void AddToPredicateTypeBasedOnIfAndOrOr<T>(ref Expression<Func<T, bool>> andPredicate,
            ref Expression<Func<T, bool>> orPredicate, Expression<Func<T, bool>> newExpression, bool isAnd)
        {
            if (isAnd)
            {
                andPredicate = andPredicate ?? BaseAnd<T>();
                andPredicate = andPredicate.And(newExpression);
            }
            else
            {
                orPredicate = orPredicate ?? BaseOr<T>();
                orPredicate = orPredicate.Or(newExpression);
            }
        }
    }
    internal class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public ReplaceVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
