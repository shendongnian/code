    public void Save(YourEntity entity)
    {
        if (entity.Id == 0)
        {
            context.YourEntity.Add(entity);
            context.SaveChanges();
        }
        else
        {
            using (var context = new YourDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges(); //Must be in using block
            }
        }            
    }
