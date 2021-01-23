    public partial class EntityClass1Service
    {
        private readonly EntitiesContext dbContext;
    
        public EntityClass1Service(EntitiesContext dbContext)
        {
            this.dbContext = dbContext;
        }
    
        public MethodUpdateString(EntityClass1 entityClass1Object)
        {
            entityClass1Object.CustomString1 = "UPDATED";
            dbContext.EntityClass1.Add(entityClass1Object);
            var entity2 = new EntityClass2();
            entity2.EntityClass1Id = entityClass1Object.Id;
            dbContext.EntityClass2.Add(entity2);
            dbContext.SaveChanges();
        }
    }
