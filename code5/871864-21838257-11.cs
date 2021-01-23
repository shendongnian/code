    class QueryWrapper<TElement> : QueryWrapperBase, IOrderedQueryable<TElement>
    {
        private static readonly MethodInfo MethodCreateQueryDef = GetMethodDefinition(q => q.CreateQuery<object>(null));
        public QueryWrapper(IQueryable<TElement> underlyingQueryable) : this(null, underlyingQueryable)
        {
        }
        protected QueryWrapper(Expression expression, IQueryable underlyingQueryable) : base(underlyingQueryable)
        {
            Expression = expression ?? Expression.Constant(this);
        }
        public virtual IEnumerator<TElement> GetEnumerator()
        {
            return ((IEnumerable<TElement>)Execute<IEnumerable>(Expression)).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Expression Expression { get; private set; }
        public Type ElementType
        {
            get { return typeof(TElement); }
        }
        public IQueryProvider Provider
        {
            get { return this; }
        }
        public override IQueryable CreateQuery(Expression expression)
        {
            var expressionType = expression.Type;
            var elementType = expressionType
                .GetInterfaces()
                .Single(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                .GetGenericArguments()
                .Single();
            var createQueryMethod = MethodCreateQueryDef.MakeGenericMethod(elementType);
            return (IQueryable)createQueryMethod.Invoke(this, new object[] { expression });
        }
        public override IQueryable<TNewElement> CreateQuery<TNewElement>(Expression expression)
        {
            return new QueryWrapper<TNewElement>(expression, UnderlyingQueryable);
        }
        private static MethodInfo GetMethodDefinition(Expression<Action<QueryWrapper<TElement>>> methodSelector)
        {
            var methodCallExpression = (MethodCallExpression)methodSelector.Body;
            return methodCallExpression.Method.GetGenericMethodDefinition();
        }
    }
