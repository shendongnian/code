    public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
    {
      dbSet.Provider.Returns(data.Provider);
      dbSet.Expression.Returns(data.Expression);
      dbSet.ElementType.Returns(data.ElementType);
      dbSet.GetEnumerator().Returns(data.GetEnumerator());
      if (dbSet is IDbAsyncEnumerable)
      {
        ((IDbAsyncEnumerable<T>) dbSet).GetAsyncEnumerator()
          .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));
        dbSet.Provider.Returns(new TestDbAsyncQueryProvider<T>(data.Provider));
      }
      return dbSet;
    }
    // create substitution with async
    var mockSet = Substitute.For<IDbSet<Blog>, IDbAsyncEnumerable<Blog>>().Initialize(data);
    // create substitution without async
    var mockSet = Substitute.For<IDbSet<Blog>>().Initialize(data);
