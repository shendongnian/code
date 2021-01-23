    public class BinaryCompareQuery<T> : IQueryable<T>, IQueryProvider
    {
        private EqualsReplacer Replacer { get; }
        private IQueryable<T> Origin { get; }
        public BinaryCompareQuery(IQueryable<T> origin)
        {
            Replacer = new EqualsReplacer();
        }
        #region IQueryable implementation
        public IEnumerator<T> GetEnumerator()
            => Origin.GetEnumerator();
        public IQueryProvider Provider
            => this;
        public Expression Expression
            => Origin.Expression;
        IEnumerator IEnumerable.GetEnumerator()
            => Origin.GetEnumerator();
        public Type ElementType
            => Origin.ElementType;
        #endregion
        #region IQueryProvider implementation
        IQueryable IQueryProvider.CreateQuery(Expression expression)
            => Origin.Provider.CreateQuery(Replacer.Visit(expression));
        IQueryable<TResult> IQueryProvider.CreateQuery<TResult>(Expression expression)
            => Origin.Provider.CreateQuery<TResult>(Replacer.Visit(expression));
        object IQueryProvider.Execute(Expression expression)
            => Origin.Provider.Execute(Replacer.Visit(expression));
        TResult IQueryProvider.Execute<TResult>(Expression expression)
            => Origin.Provider.Execute<TResult>(Replacer.Visit(expression));
        #endregion
    }
