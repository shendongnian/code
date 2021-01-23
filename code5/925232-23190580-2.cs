    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
        public virtual bool Deletecustomer(int id ,bool IsDeleted )
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<bool>("EXEC checkbit({0},{1})", id,IsDeleted ).SingleOrDefault();
        }
