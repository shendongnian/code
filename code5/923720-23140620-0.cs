    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
 
    public class MockDbSet<TEntity> : DbSet<TEntity>, IQueryable<TEntity> where TEntity : class
    {
        private List<TEntity> list = null;
 
        /// <summary>Initializes a new instance of the MockDbSet class.</summary>
        public MockDbSet(IEnumerable<TEntity> collection)
        {
            this.list = new List<TEntity>(collection);
        }
 
        public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            list.AddRange(entities);
 
            return list;
        }
 
        public override TEntity Add(TEntity entity)
        {
            list.Add(entity);
           
            return entity;
        }
 
        public override TEntity Attach(TEntity entity)
        {
            return entity;
        }
 
        public new TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity
        {
            return (TDerivedEntity)list.FirstOrDefault();
        }
 
        public override TEntity Create()
        {
            return list.FirstOrDefault();
        }
 
        public override TEntity Find(params object[] keyValues)
        {
            return null;
        }
 
        public override System.Collections.ObjectModel.ObservableCollection<TEntity> Local
        {
            get { return new System.Collections.ObjectModel.ObservableCollection<TEntity>(this.list); }
        }
 
        public override TEntity Remove(TEntity entity)
        {
            list.Remove(entity);
            return entity;
        }
 
        public IEnumerator<TEntity> GetEnumerator()
        {
            return list.GetEnumerator();
        }
 
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
 
        public Type ElementType
        {
            get { return this.list.AsQueryable().ElementType; }
        }
 
        public System.Linq.Expressions.Expression Expression
        {
            get { return this.list.AsQueryable().Expression; }
        }
 
        public IQueryProvider Provider
        {
            get { return this.list.AsQueryable().Provider; }
        }
    }
