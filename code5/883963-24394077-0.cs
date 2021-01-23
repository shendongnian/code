        public static Mock<DbSet<T>> createFakeDBSet<T>(this Mock<DbContext> db, List<T> list = null, Func<List<T>, object[], T> find = null) where T : class, new()
        {
            list = list ?? new List<T>();
            var data = list.AsQueryable();
            
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(() => { return data.Provider; });
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(() => { return data.Expression; });
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(() => { return data.ElementType; });
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => { return list.GetEnumerator(); });
            mockSet.Setup(m => m.Add(It.IsAny<T>())).Returns<T>(i => { list.Add(i); return i; });
            mockSet.Setup(m => m.AddRange(It.IsAny<IEnumerable<T>>())).Returns<IEnumerable<T>>((i) => { list.AddRange(i); return i; });
            mockSet.Setup(m => m.Remove(It.IsAny<T>())).Returns<T>(i => { list.Remove(i); return i; });
            if (find != null) mockSet.As<IDbSet<T>>().Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>((i) => { return find(list, i); });
            db.Setup(x => x.Set<T>()).Returns(mockSet.Object);
            return mockSet;
        }
