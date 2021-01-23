    // using E = System.Linq.Expressions.Expression;
    sealed class ParameterReplacementVisitor : ExpressionVisitor
    {
        private readonly IDictionary<E, E> _replacements;
        public ParameterReplacementVisitor(IDictionary<E, E> replacements)
        {
            _replacements = replacements;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            E replacement;
            
            if (_replacements.TryGetValue(node, out replacement))
                return this.Visit(replacement);
            return base.VisitParameter(node);
        }
    }
    // ...
    
    var item = E.Parameter(typeof(TView));
    
    var visitor = new ParameterReplacementVisitor(
        new Dictionary<E, E> {
            { parentCodeFilterExpression.Parameters[0], item },
            { textFilterExpression.Parameters[0], item }
        }
    );
    var combined = E.Lambda<Func<TView, bool>>(
        E.AndAlso(
            visitor.Visit(parentCodeFilterExpression.Body), 
            visitor.Visit(textFilterExpression.Body)), 
        item);
