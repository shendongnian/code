    public static class DbSetMock
    {
        public static Mock<DbSet<T>> CreateFrom<T>(List<T> list) where T : class
        {
            var internalQueryable = list.AsQueryable();
            var mock = new Mock<DbSet<T>>();
            mock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(internalQueryable.Provider);
            mock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(internalQueryable.Expression);
            mock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(internalQueryable.ElementType);
            mock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(()=> internalQueryable.GetEnumerator());
            mock.As<IDbSet<T>>().Setup(x => x.Add(It.IsAny<T>())).Callback<T>(element => list.Add(element));
            mock.As<IDbSet<T>>().Setup(x => x.Remove(It.IsAny<T>())).Callback<T>(element => list.Remove(element));
            return mock;
        }
    }
