    abstract class QueryWrapperBase : IQueryProvider, IQueryWrapper
    {
        public IQueryable UnderlyingQueryable { get; private set; }
        class ObjectWrapperReplacer : ExpressionVisitor
        {
            public override Expression Visit(Expression node)
            {
                if (node == null || !typeof(IQueryWrapper).IsAssignableFrom(node.Type)) return base.Visit(node);
                var wrapper = EvaluateExpression<IQueryWrapper>(node);
                return Expression.Constant(wrapper.UnderlyingQueryable);
            }
            public static Expression FixExpression(Expression expression)
            {
                var replacer = new ObjectWrapperReplacer();
                return replacer.Visit(expression);
            }
            private T EvaluateExpression<T>(Expression expression)
            {
                if (expression is ConstantExpression) return (T)((ConstantExpression)expression).Value;
                var lambda = Expression.Lambda(expression);
                return (T)lambda.Compile().DynamicInvoke();
            }
        }
        protected QueryWrapperBase(IQueryable underlyingQueryable)
        {
            UnderlyingQueryable = underlyingQueryable;
        }
        public abstract IQueryable<TElement> CreateQuery<TElement>(Expression expression);
        public abstract IQueryable CreateQuery(Expression expression);
        public TResult Execute<TResult>(Expression expression)
        {
            return (TResult)Execute(expression);
        }
        public object Execute(Expression expression)
        {
            expression = ObjectWrapperReplacer.FixExpression(expression);
            return typeof(IQueryable).IsAssignableFrom(expression.Type)
                ? ExecuteQueryable(expression)
                : ExecuteNonQueryable(expression);
        }
        protected object ExecuteNonQueryable(Expression expression)
        {
            return UnderlyingQueryable.Provider.Execute(expression);
        }
        protected IQueryable ExecuteQueryable(Expression expression)
        {
            return UnderlyingQueryable.Provider.CreateQuery(expression);
        }
    }
