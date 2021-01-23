    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using Moq;
    using Moq.Language.Flow;
    public static class DbMockHelpers
    {
        public static Mock<IDbSet<TEntity>> MockSingle<TEntity>(TEntity data) 
            where TEntity : class, new()
        {
            return MockDbSet(new[] { data });
        }
        public static Mock<IDbSet<TEntity>> MockDbSet<TEntity>(params TEntity[] data)
            where TEntity : class, new()
        {
            return MockDbSet(data.AsEnumerable());
        }
        public static Mock<IDbSet<TEntity>> MockDbSet<TEntity>(IEnumerable<TEntity> data) 
            where TEntity : class, new()
        {
            var list = data == null ? new List<TEntity>() : data.ToList();
            var observable = new ObservableCollection<TEntity>(list);
            var dbSet = new Mock<IDbSet<TEntity>>();
            dbSet.Setup(d => d.Add(It.IsAny<TEntity>())).Callback((TEntity entity) => list.Add(entity));
            dbSet.Setup(d => d.Remove(It.IsAny<TEntity>())).Callback((TEntity entity) => list.Remove(entity));
            dbSet.Setup(d => d.Attach(It.IsAny<TEntity>())).Callback((TEntity entity) => list.Add(entity));
            dbSet.Setup(d => d.Create()).Returns(new TEntity());
            dbSet.Setup(d => d.GetEnumerator()).Returns(() => list.GetEnumerator());
            dbSet.Setup(d => d.Local).Returns(observable);
            dbSet.Setup(d => d.ElementType).Returns(typeof(TEntity));
            dbSet.Setup(d => d.Provider).Returns(list.AsQueryable().Provider);
            dbSet.Setup(d => d.Expression).Returns(list.AsQueryable().Expression);
            return dbSet;
        } 
        public static IDbSet<TEntity> DbSet<TEntity>(IEnumerable<TEntity> data) 
            where TEntity : class, new()
        {
            return MockDbSet(data).Object;
        }
        public static IDbSet<TEntity> DbSet<TEntity>(params TEntity[] data)
            where TEntity : class, new()
        {
            return MockDbSet(data).Object;
        }
        // commenting out this method allowed the project to compile without the reference to EF
        public static IReturnsResult<T> ReturnsSet<T, TProperty, TEntity>(this ISetupGetter<T, TProperty> setupGetter, params TEntity[] data)
            where T : class
            where TProperty : IDbSet<TEntity>
            where TEntity : class, new()
        {
            return setupGetter.Returns((TProperty)DbSet(data));
        }
    }
