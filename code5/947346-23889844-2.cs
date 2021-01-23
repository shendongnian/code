    // Sorry for the atrocious formatting, wanted to keep it scrollbar-free
    class ParameterReplacementVisitor : ExpressionVisitor
    {
        private readonly
        IEnumerable<KeyValuePair<ParameterExpression, ParameterExpression>>
        replacementMap;
    
        public ParameterReplacementVisitor(
            IEnumerable<KeyValuePair<ParameterExpression, ParameterExpression>> map)
        {
            this.replacementMap = map;
        }
    
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return Expression.Lambda<T>(
                Visit(node.Body),
                node.Parameters.Select(Visit).Cast<ParameterExpression>());
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
    	    var replacement = this.replacementMap
                                  .Where(p => p.Key == node)
                                  .DefaultIfEmpty()
                                  .First().Value;
            return base.VisitParameter(replacement ?? node);
        }
    }
