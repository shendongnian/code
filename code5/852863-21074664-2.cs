    public static class ExtentionMethods
    {
        public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.AsQueryable().Provider.Returns(data.Provider);
            dbSet.AsQueryable().Expression.Returns(data.Expression);
            dbSet.AsQueryable().ElementType.Returns(data.ElementType);
            dbSet.AsQueryable().GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }
    // usage like:
    var mockSet = Substitute.For<IDbSet<Blog>>().Initialize(data);
