    public class MyDBContext : DbContext
    {
        public virtual T GetEntityByPrimaryKey<T>(T entity) where T : class
        {
            var entityType = entity.GetType();
            var objectSet = ((IObjectContextAdapter)this).ObjectContext.CreateObjectSet<T>();
            var keyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(edmMember => edmMember.Name);
            var keyValues = keyNames.Select(name => entityType.GetProperty(name).GetValue(entity, null)).ToArray();
            return this.Set<T>().Find(keyValues);
        }
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry.Entity is IMyValidationInterface)
            {
                var validationContext = new MyDBContext();
                
                var modifiedEntity = entityEntry.Entity;
                var originalEntity = validationContext.GetEntityByPrimaryKey(a);
                items.Add("OriginalEntity", originalEntity);
            }
            return base.ValidateEntity(entityEntry, items);
        }
    }
