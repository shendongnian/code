    class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression target;
        private readonly ISet<ParameterExpression> sources;
    
        internal ParameterReplacer(ParameterExpression target,
                                   IEnumerable<LambdaExpression> expressions)
        {
            this.target = target;
            sources = new HashSet<ParameterExpression>(
                expressions.SelectMany(e => e.Parameters));
        }
    
        protected override Expression VisitParameter
            (ParameterExpression node)
        {
            return sources.Contains(node) ? target : node;
        }
    }
