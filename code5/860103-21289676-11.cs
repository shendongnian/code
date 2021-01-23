    public static class LambadaConverter
    {
        /// <summary>
        /// Converts a many parametered expression in to a single paramter expression using a set of mappers to go from the source type to mapped source.
        /// </summary>
        /// <typeparam name="TNewSourceType">The datatype for the new soruce type</typeparam>
        /// <typeparam name="TResult">The return type of the old lambada return type.</typeparam>
        /// <param name="query">The query to convert.</param>
        /// <param name="parameterMapping">The mappers to go from the single source class to a set of </param>
        /// <returns></returns>
        public static Expression<Func<TNewSourceType, TResult>>  Convert<TNewSourceType, TResult>(Expression query, params Expression[] parameterMapping)
        {
            //Doing some pre-condition checking to make sure everything was passed in correctly.
            var castQuery = query as LambdaExpression;
            if (castQuery == null)
                throw new ArgumentException("The passed in query must be a lambada expression", "query");
            if (parameterMapping.Any(expression => expression is LambdaExpression == false) ||
                parameterMapping.Any(expression => ((LambdaExpression)expression).Parameters.Count != 1) ||
                parameterMapping.Any(expression => ((LambdaExpression)expression).Parameters[0].Type != typeof(TNewSourceType)))
            {
                throw new ArgumentException("Each pramater mapper must be in the form of \"Expression<Func<TNewSourceType,TResut>>\"",
                                            "parameterMapping");
            }
            //We need to remap all the input mappings so they all share a single paramter variable.
            var inputParameter = Expression.Parameter(typeof(TNewSourceType));
            //Perform the mapping-remapping.
            var normlizer = new ParameterNormalizerVisitor(inputParameter);
            var mapping = normlizer.Visit(new ReadOnlyCollection<Expression>(parameterMapping));
            //Perform the mapping on the expression query.
            var customVisitor = new LambadaVisitor<TNewSourceType, TResult>(mapping, inputParameter);
            return (Expression<Func<TNewSourceType, TResult>>)customVisitor.Visit(query);
        }
        /// <summary>
        /// Causes the entire series of input lambadas to all share the same 
        /// </summary>
        private class ParameterNormalizerVisitor : ExpressionVisitor
        {
            public ParameterNormalizerVisitor(ParameterExpression parameter)
            {
                _parameter = parameter;
            }
            private readonly ParameterExpression _parameter;
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if(node.Type == _parameter.Type)
                    return _parameter;
                else
                    throw new InvalidOperationException("Was passed a parameter type that was not expected.");
            }
        }
        /// <summary>
        /// Rewrites the output query to use the new remapped inputs.
        /// </summary>
        private class LambadaVisitor<TSource,TResult> : ExpressionVisitor
        {
            public LambadaVisitor(ReadOnlyCollection<Expression> parameterMapping, ParameterExpression newParameter)
            {
                _parameterMapping = parameterMapping;
                _newParameter = newParameter;
            }
            private readonly ReadOnlyCollection<Expression> _parameterMapping;
            private readonly ParameterExpression _newParameter;
            private ReadOnlyCollection<ParameterExpression> _oldParameteres = null;
            protected override Expression VisitParameter(ParameterExpression node)
            {
                //Check to see if this is one of our known parameters, and replace the body if it is.
                var index = _oldParameteres.IndexOf(node);
                if (index >= 0)
                {
                    return ((LambdaExpression)_parameterMapping[index]).Body;
                }
                //Not one of our known parameters, process as normal.
                return base.VisitParameter(node);
            }
            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                if (_oldParameteres == null)
                {
                    _oldParameteres = node.Parameters;
                    var newBody = this.Visit(node.Body);
                    return Expression.Lambda<Func<TSource, TResult>>(newBody, _newParameter);
                }
                else
                    throw new InvalidOperationException("Encountered more than one Lambada, not sure how to handle this.");
            }
        }
    }
