    //http://blogs.msdn.com/b/meek/archive/2008/05/02/linq-to-entities-combining-predicates.aspx
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly IDictionary<ParameterExpression, ParameterExpression> _map;
        public ParameterRebinder(IDictionary<ParameterExpression, ParameterExpression> map)
        {
            _map = map;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (_map.ContainsKey(node))
            {
                return _map[node];
            }
            return base.VisitParameter(node);
        }
    }
