    private void UpdateExistingMyEntity(IEnumerable<MyEntity> updatedEntities)
    {
        using (var context = new MyEntitiesContext())
        {
            foreach(MyEntity e in updatedEntities)
                context.Entry(e).State = EntityState.Modified;
            context.SaveChanges(); 
        }
    }
