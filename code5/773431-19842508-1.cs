        class ReplaceVisitor : ExpressionVisitor
        {
            readonly Expression to;
            readonly ParameterExpression @from;
            public ReplaceVisitor(ParameterExpression from, Expression to)
            {
                this.to = to;
                this.@from = @from;
            }
            public override Expression Visit(Expression node)
            {
                if (node == @from)
                    return @to;
                return base.Visit(node);
            }
        }
