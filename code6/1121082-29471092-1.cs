        private class ResolveQuoteVisitor : ExpressionVisitor
        {
            public ResolveQuoteVisitor()
            {
                m_asQuoteMethod = typeof(Extensions).GetMethod("AsQuote").GetGenericMethodDefinition();
            }
            MethodInfo m_asQuoteMethod;
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (IsAsquoteMethodCall(node))
                {
                    // we cant handle here parameters, so just ignore them for now
                    return Visit(ExtractQuotedExpression(node).Body);
                }
                return base.VisitMethodCall(node);
            }
            private bool IsAsquoteMethodCall(MethodCallExpression node)
            {
                return node.Method.IsGenericMethod && node.Method.GetGenericMethodDefinition() == m_asQuoteMethod;
            }
            private LambdaExpression ExtractQuotedExpression(MethodCallExpression node)
            {
                var quoteExpr = node.Arguments[0];
                // you know this is a method call to a static method without parameters
                // you can do the easiest: compile it, and then call:
                // alternatively you could call the method with reflection
                // or even cache the value to the method in a static dictionary, and take the expression from there (the fastest)
                // the choice is up to you. as an example, i show you here the most generic solution (the first)
                return (LambdaExpression)Expression.Lambda(quoteExpr).Compile().DynamicInvoke();
            }
        }
