    string lastMemberName = new MyVisitor().GetLastVisitedMember(exp);
    
    class MyVisitor : ExpressionVisitor
    {
        private string memberName = "";
        public string GetLastVisitedMember(Expression exp)
        {
            Visit(exp);
            return memberName;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            memberName = node.Member.Name;
            return base.VisitMember(node);
        }
    }
