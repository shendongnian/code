        internal class ResultSelectorRewriter<TOuter, TInner, TResult> : ExpressionVisitor
        {
            private Expression<Func<TOuter, TInner, TResult>> resultSelector;
            public Expression<Func<KeyValuePairHolder<TOuter, IEnumerable<TInner>>, TInner, TResult>> CombinedExpression { get; private set; }
        
            private ParameterExpression OldTOuterParamExpression;
            private ParameterExpression OldTInnerParamExpression;
            private ParameterExpression NewTOuterParamExpression;
            private ParameterExpression NewTInnerParamExpression;
        
        
            public ResultSelectorRewriter(Expression<Func<TOuter, TInner, TResult>> resultSelector)
            {
                this.resultSelector = resultSelector;
                this.OldTOuterParamExpression = resultSelector.Parameters[0];
                this.OldTInnerParamExpression = resultSelector.Parameters[1];
        
                this.NewTOuterParamExpression = Expression.Parameter(typeof(KeyValuePairHolder<TOuter, IEnumerable<TInner>>));
                this.NewTInnerParamExpression = Expression.Parameter(typeof(TInner));
        
                var newBody = this.Visit(this.resultSelector.Body);
                var combinedExpression = Expression.Lambda(newBody, new ParameterExpression[] { this.NewTOuterParamExpression, this.NewTInnerParamExpression });
                this.CombinedExpression = (Expression<Func<KeyValuePairHolder<TOuter, IEnumerable<TInner>>, TInner, TResult>>)combinedExpression;
            }
        
        
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node == this.OldTInnerParamExpression)
                    return this.NewTInnerParamExpression;
                else if (node == this.OldTOuterParamExpression)
                    return Expression.PropertyOrField(this.NewTOuterParamExpression, "Item1");
                else
                    throw new InvalidOperationException("What is this sorcery?", new InvalidOperationException("Did not expect a parameter: " + node));
            } 
        }
