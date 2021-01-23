    class ObjectSetWrapperQueryProvider<TEntity> : IQueryProvider
    {
        private readonly IQueryProvider UnderlyingProvider;
        class ObjectSetWrapperReplacer : ExpressionVisitor
        {
            protected override Expression VisitConstant(ConstantExpression node)
            {
                var objSet = node.Value as IObjectSet<TEntity>;
                if (objSet == null) return base.VisitConstant(node);
                
                return Expression.Constant(objSet.ObjectSet);
            }
            
            public static Expression FixExpression(Expression expression)
            {
                var replacer = new ObjectSetWrapperReplacer();
                return replacer.Visit(expression);
            }
        }
        public ObjectSetWrapperQueryProvider(IQueryProvider underlyingProvider)
        {
            UnderlyingProvider = underlyingProvider;
        }
        public T Execute<T>(Expression expression)
        {
            var fixedExpression = ObjectSetWrapperReplacer.FixExpression(expression);
            return UnderlyingProvider.Execute<T>(fixedExpression);
        }
        public object ExecuteExpression expression)
        {
            var fixedExpression = ObjectSetWrapperReplacer.FixExpression(expression);
            return UnderlyingProvider.Execute(fixedExpression);
        }
    }
