    internal class MemberAccesses : ExpressionVisitor
    {
        private ParameterExpression parameter;
        public HashSet<MemberExpression> Members { get; private set; }
        public MemberAccesses(ParameterExpression parameter)
        {
            this.parameter = parameter;
            Members = new HashSet<MemberExpression>();
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression == parameter)
            {
                Members.Add(node);
            }
            return base.VisitMember(node);
        }
    }
    public static IEnumerable<MemberExpression> GetPropertyAccesses<T, TResult>(
        this Expression<Func<T, TResult>> expression)
    {
        var visitor = new MemberAccesses(expression.Parameters[0]);
        visitor.Visit(expression);
        return visitor.Members;
    }
