    public class PredicateBuilder<T>
    {
        // We share a single parameter for all the PredicatBuilder<T>
        // istances. This isn't a proble, because Expressions are immutable
        protected static readonly ParameterExpression Parameter = Expression.Parameter(typeof(T), "x");
        protected Expression Current { get; set; }
        // Returns an empty PredicateBuilder that, if used, is true
        public PredicateBuilder()
        {
        }
        // Use it like this: .Where(predicate) or .Any(predicate) or 
        // .First(predicate) or...
        public static implicit operator Expression<Func<T, bool>>(PredicateBuilder<T> predicate)
        {
            if (object.ReferenceEquals(predicate, null))
            {
                return null;
            }
            // Handling of empty PredicateBuilder
            Expression current = predicate.Current ?? Expression.Constant(true);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(current, Parameter);
            return lambda;
        }
        public static implicit operator PredicateBuilder<T>(Expression<Func<T, bool>> expression)
        {
            var predicate = new PredicateBuilder<T>();
            if (expression != null)
            {
                // Equivalent to predicate.Or(expression)
                predicate.And(expression);
            }
            return predicate;
        }
        public void And(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            var expression2 = new ParameterConverter(expression.Parameters[0], Parameter).Visit(expression.Body);
            this.Current = this.Current != null ? Expression.AndAlso(this.Current, expression2) : expression2;
        }
        public void Or(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            var expression2 = new ParameterConverter(expression.Parameters[0], Parameter).Visit(expression.Body);
            this.Current = this.Current != null ? Expression.OrElse(this.Current, expression2) : expression2;
        }
        public override string ToString()
        {
            // We reuse the .ToString() of Expression<Func<T, bool>>
            // Implicit cast here :-)
            Expression<Func<T, bool>> expression = this;
            return expression.ToString();
        }
        // Small ExpressionVisitor that replaces the ParameterExpression of
        // an Expression with another ParameterExpression (to make two
        // Expressions "compatible")
        protected class ParameterConverter : ExpressionVisitor
        {
            public readonly ParameterExpression From;
            public readonly ParameterExpression To;
            public ParameterConverter(ParameterExpression from, ParameterExpression to)
            {
                this.From = from;
                this.To = to;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node == this.From)
                {
                    node = this.To;
                }
                return base.VisitParameter(node);
            }
        }
    }
    public static class PredicateBuilder
    {
        // The value of source isn't really necessary/interesting. Its type
        // is :-) By passing a query you are building to Create, the compiler
        // will give to Create the the of the object returned from the query
        // Use it like:
        // var predicate = PredicateBuilder.Create<MyType>();
        // or
        // var predicate = PredicateBuilder.Create(query);
        public static PredicateBuilder<T> Create<T>(IEnumerable<T> source = null)
        {
            return new PredicateBuilder<T>();
        }
        // Useful if you want to start with a query:
        // var predicate = PredicateBuilder.Create<MyType>(x => x.ID != 0);
        // Note that if expression == null, then a new PredicateBuilder<T>()
        // will be returned (that by default is "true")
        public static PredicateBuilder<T> Create<T>(Expression<Func<T, bool>> expression)
        {
            // Implicit cast to PredicateBuilder<T>
            return expression;
        }
    }
