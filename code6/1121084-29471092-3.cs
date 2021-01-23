            protected override Expression VisitInvocation(InvocationExpression node)
            {
                if (node.Expression.NodeType == ExpressionType.Call && IsAsquoteMethodCall((MethodCallExpression)node.Expression))
                {
                    var targetLambda = ExtractQuotedExpression((MethodCallExpression)node.Expression);
                    var replaceParamsVisitor = new MultiParamReplaceVisitor(node.Arguments.ToArray(), targetLambda);
                    return Visit(replaceParamsVisitor.Replace());
                }
                return base.VisitInvocation(node);
            }
