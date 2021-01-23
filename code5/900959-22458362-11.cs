    class Visitor : ExpressionVisitor
    {
        private Expression param;
    	
        public Visitor(Expression param)
        {
            this.param = param;
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return param;
        }
    }
