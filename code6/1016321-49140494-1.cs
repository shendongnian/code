        public static Mock<DbSqlQuery<TEntity>> CreateDbSqlQuery<TEntity>(IList<TEntity> data)
            where TEntity : class, new()
        {
            var source = data.AsQueryable();
            var mock = new Mock<DbSqlQuery<TEntity>>() {CallBase = true};
            mock.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(source.Expression);
            mock.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(source.ElementType);
            mock.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(source.GetEnumerator());
            mock.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<TEntity>(source.Provider));
            mock.As<IDbAsyncEnumerable<TEntity>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<TEntity>(data.GetEnumerator()));
            mock.As<IDbSet<TEntity>>().Setup(m => m.Create()).Returns(new TEntity());
            mock.As<IDbSet<TEntity>>().Setup(m => m.Add(It.IsAny<TEntity>())).Returns<TEntity>(i => { data.Add(i); return i; });
            mock.As<IDbSet<TEntity>>().Setup(m => m.Remove(It.IsAny<TEntity>())).Returns<TEntity>(i => { data.Remove(i); return i; });
            return mock;
        }
