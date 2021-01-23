    internal class ParameterAccessesVisitor : ExpressionVisitor
    {
        private ReadOnlyCollection<ParameterExpression> parameters;
        public ParameterAccessesVisitor(
            ReadOnlyCollection<ParameterExpression> parameters)
        {
            VisitedMembers = new List<MemberInfo>();
            this.parameters = parameters;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (parameters.Contains(node.Expression))
                VisitedMembers.Add(node.Member);
            return base.VisitMember(node);
        }
        public List<MemberInfo> VisitedMembers { get; private set; }
    }
