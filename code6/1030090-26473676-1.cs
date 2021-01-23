        public class HqlEscape : HqlExpression
        {
            public HqlEscape(IASTFactory factory, params HqlTreeNode[] children)
                : base(HqlSqlWalker.ESCAPE, "escape", factory, children)
            {
            }
        }
