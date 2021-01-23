    public static class MockingHelper
    {
        public static Mock<DbSet<TEntity>> AsMockDbSet<TEntity>(this IQueryable<TEntity> data)
            where TEntity : class
        {
            var mockSet = new Mock<DbSet<TEntity>>();
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<TEntity>(data.Provider));
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.As<IDbAsyncEnumerable<TEntity>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<TEntity>(data.GetEnumerator()));
            return mockSet;
        }
        public static Mock<DbSet<TEntity>> AsMockDbSet<TEntity>(this IEnumerable<TEntity> data)
            where TEntity : class
        {
            return data.AsQueryable().AsMockDbSet();
        }
    }
