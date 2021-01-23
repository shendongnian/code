    public class DeletedFilterInterceptor: ExpressionVisitor
    {
        public Expression<Func<Entity, bool>> Filter { get; set; }
        public DeletedFilterInterceptor()
        {
            Filter = entity => !entity.Deleted;
        }
        protected override Expression VisitMember(MemberExpression ex)
        {
            return !ex.Type.IsGenericType ? base.VisitMember(ex) : CreateWhereExpression(Filter, ex) ?? base.VisitMember(ex);
        }
        private Expression CreateWhereExpression(Expression<Func<Entity, bool>> filter, Expression ex)
        {
            var type = ex.Type;//.GetGenericArguments().First();
            var test = CreateExpression(filter, type);
            if (test == null)
                return null;
            var listType = typeof(IQueryable<>).MakeGenericType(type);
            return Expression.Convert(Expression.Call(typeof(Enumerable), "Where", new Type[] { type }, (Expression)ex, test), listType);
        }
        private LambdaExpression CreateExpression(Expression<Func<Entity, bool>> condition, Type type)
        {
            var lambda = (LambdaExpression) condition;
            if (!typeof(Entity).IsAssignableFrom(type))
                return null;
            var newParams = new[] { Expression.Parameter(type, "entity") };
            var paramMap = lambda.Parameters.Select((original, i) => new { original, replacement = newParams[i] }).ToDictionary(p => p.original, p => p.replacement);
            var fixedBody = ParameterRebinder.ReplaceParameters(paramMap, lambda.Body);
            lambda = Expression.Lambda(fixedBody, newParams);
            return lambda;
        }
    }
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (_map.TryGetValue(node, out replacement))
                node = replacement;
            return base.VisitParameter(node);
        }
    }
