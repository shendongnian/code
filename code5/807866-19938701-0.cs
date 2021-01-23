        protected override Expression VisitMember(MemberExpression node)
        {
            string sDbField = ((SFWBusinessAttributes)node.Expression.Type.GetProperty(node.Member.Name).GetCustomAttribu`tes(typeof(SFWBusinessAttributes), true)[0]).DBColumn;
            var expr = Visit(node.Expression);
            if (expr.Type != node.Type)
            {
                MemberInfo newMember = expr.Type.GetMember(sDbField).Single();
                return Expression.MakeMemberAccess(expr, newMember);
            }
            return base.VisitMember(node);
        }
