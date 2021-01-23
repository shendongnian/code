        public Mock<IDbSet<T>> CreateMockDbSet<T>(IQueryable<T> data) where T:     
          class
        {
            var dbSet = new Mock<IDbSet<T>>();
            dbSet.Setup(m => m.Provider).Returns(data.Provider);
            dbSet.Setup(m => m.Expression).Returns(data.Expression);
            dbSet.Setup(m => m.ElementType).Returns(data.ElementType);
            dbSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return dbSet;
        }
