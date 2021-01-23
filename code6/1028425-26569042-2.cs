    public class ParameterVisitor : ExpressionVisitor
    {
        private readonly ReadOnlyCollection<ParameterExpression> from;
        // Changed from ReadOnlyCollection of ParameterExpression to Expression 
        private readonly Expression[] to;
        public ParameterVisitor(ReadOnlyCollection<ParameterExpression> from, params Expression[] to)
        {
            if (from == null) throw new ArgumentNullException("from");
            if (to == null) throw new ArgumentNullException("to");
            if (from.Count != to.Length)
                throw new InvalidOperationException(
                    "Parameter lengths must match");
            this.from = from;
            this.to = to;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            for (int i = 0; i < from.Count; i++)
            {
                if (node == from[i]) return to[i];
            }
            return node;
        }
    }
