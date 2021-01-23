            var parentMember = node.Expression as MemberExpression;
            if (parentMember != null)
            {
                var grandparent = parentMember.Expression;
                var converted = Expression.MakeMemberAccess(
                        base.Visit(grandparent),
                        property
                        );
                return converted;
            }
            else
            {
                var converted = Expression.MakeMemberAccess(
                        base.Visit(node.Expression),
                        property
                        );
                return converted;
            }
