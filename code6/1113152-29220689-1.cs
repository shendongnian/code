    public static IQueryable<TFilteredItem> ApplyFilter<TFilteredItem, TEnum>(IQueryable<TFilteredItem> items, IEnumerable<TEnum> enumValues, Expression<Func<TFilteredItem, IEnumerable<TEnum>, bool>> predicate)
    {
        ParameterExpression itemParam = predicate.Parameters[0];
        ParameterExpression enumsParam = predicate.Parameters[1];
        var em = new ExpressionModifier<IEnumerable<TEnum>>(enumsParam.Name, enumValues);
        Expression predicateBody = em.Modify(predicate.Body);
        return items.Where(Expression.Lambda<Func<TFilteredItem, bool>>(predicateBody, new[] { itemParam }));
    }
    public class ExpressionModifier<T> : ExpressionVisitor
    {
        private readonly string parameterName;
        private readonly T newValue;
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }
        public ExpressionModifier(string parameterName, T newValue)
        {
            this.parameterName = parameterName;
            this.newValue = newValue;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node.Name == this.parameterName ? Expression.Constant(this.newValue, node.Type) : base.VisitParameter(node);
        }
    }
