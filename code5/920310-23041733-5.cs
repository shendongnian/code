    class ParameterReplacementVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _paramToReplace;
        private readonly Expression _replacementExpression;
        public ParameterReplacementVisitor(ParameterExpression paramToReplace, Expression replacementExpression)
        {
            _paramToReplace = paramToReplace;
            _replacementExpression = replacementExpression;
        }
        
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _paramToReplace)
                return _replacementExpression;
            return base.VisitParameter(node);
        }
    }
