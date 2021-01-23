        private class MultiParamReplaceVisitor : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, Expression> m_replacements;
            private readonly LambdaExpression m_expressionToVisit;
            public MultiParamReplaceVisitor(Expression[] parameterValues, LambdaExpression expressionToVisit)
            {
                // do null check
                if (parameterValues.Length != expressionToVisit.Parameters.Count)
                    throw new ArgumentException(string.Format("The paraneter values count ({0}) does not match the expression parameter count ({1})", parameterValues.Length, expressionToVisit.Parameters.Count));
                m_replacements = expressionToVisit.Parameters
                    .Select((p, idx) => new { Idx = idx, Parameter = p })
                    .ToDictionary(x => x.Parameter, x => parameterValues[x.Idx]);
                m_expressionToVisit = expressionToVisit;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                Expression replacement;
                if (m_replacements.TryGetValue(node, out replacement))
                    return Visit(replacement);
                return base.VisitParameter(node);
            }
            public Expression Replace()
            {
                return Visit(m_expressionToVisit.Body);
            }
        }
