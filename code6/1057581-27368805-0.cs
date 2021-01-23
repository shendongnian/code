    class EntityObjectDAL 
    {
        private ObjectContext/DbContext context = new ObjectContext/DbContext();
      
        public List<EntityObject> GetObjects() { return context.EntityObjects.ToList(); }
        // Tracked by context. Just change it in BL
        public void SaveObjects() { context.SaveChanges(); }
        // Just call SaveChanges(), no need for anything special...
        public void InsertObject(EntityObject eo) { context.EntityObjects.Add(eo); }
        public void UpdateObject(EntityObject eo) { context.Entry(eo).State = EntityState.Modified; }
    } 
