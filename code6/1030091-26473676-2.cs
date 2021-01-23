        public class HqlLikeWithEscape : HqlBooleanExpression
        {
            public HqlLikeWithEscape(IASTFactory factory, HqlExpression lhs, HqlExpression rhs, HqlEscape escape)
                : base(HqlSqlWalker.LIKE, "like", factory, lhs, rhs, escape)
            {
            }
        }
