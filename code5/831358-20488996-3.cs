    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Validation;
    using System.Linq.Expressions;
    namespace repofT
    {
    /// <summary>
    /// Note to the reader. NO error handling. You should add your preferred solution.
    /// This is a stripped down sample to illustrate how Repository of T pattern works.
    ///  </summary>
    public class MyContext : DbContext
    {
       public DbSet<MyPoco>  MyPocos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //fluent API....
            base.OnModelCreating(modelBuilder);
            var entity = modelBuilder.Entity<MyPoco>();
            entity.HasKey(t => t.Id)   ;
            entity.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
    public class MyPoco
    {
        //virtuals for EF, especially Proxies and navigation, Use public get/set
     public virtual   int Id { get; set; }
     public virtual   string Content { get; set; }
    }
    public class Repository<TPoco> where TPoco : class, new()
    {
        public DbContext Context { get; private set; }
        public Repository(DbContext context){
            Context = context;
        }
        public IList<TPoco> GetList(Expression<Func<TPoco, bool>> predicate)
        {
            // Investigate returning IQueryable versus IList as you learn more.
            return GetQuery(predicate).ToList();
        }
        public IQueryable<TPoco> GetQuery(Expression<Func<TPoco, bool>> predicate)
        {
            // Investigate returning IQueryable versus IList as you learn more.
            return Context.Set<TPoco>().Where(predicate);
        }
        public TPoco Get(Expression<Func<TPoco, bool>> predicate)
        {
            return Context.Set<TPoco>().FirstOrDefault(predicate);
        }
        public TPoco Find(params object[] keyValues)
        {
            return Context.Set<TPoco>().Find(keyValues);
        } 
        public TPoco Attach(TPoco poco)
        {
            return Context.Set<TPoco>().Add(poco);
        }
        public TPoco Add(TPoco poco){
            return Context.Set<TPoco>().Add(poco);
        }
        public TPoco AddOrUpdate(TPoco poco){
            return Context.Set<TPoco>().Add(poco);
        }
        public TPoco Remote(TPoco poco){
            return Context.Set<TPoco>().Remove(poco);
        }
        public void Change(TPoco poco){
            Context.ChangeTracker.DetectChanges();
        }
        public void SetEntityState(TPoco poco, EntityState state = EntityState.Modified){
            Context.Entry(poco).State = state;
        }
    }
    public class UnitOfWork
    {
        public DbContext Context { get; protected set; }
        public  UnitOfWork(DbContext context){
            Context = context;
        }
         public IEnumerable<DbEntityValidationResult> GetDbValidationErrors() { return 
            Context.GetValidationErrors(); 
         }
        public int Commit()
        {
            try {
                var recs = Context.SaveChanges();
                return recs;
            }
           catch (DbEntityValidationException efException){
               var errors = GetDbValidationErrors(); // DO SOMETHING HERE !!!!!
               return -1;
           }
        }
    }
    }
