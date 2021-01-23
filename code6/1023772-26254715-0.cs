    private void addEntitiesToDbContext(List<BaseEntity> ent, MyTypeContext dbContext)
    {
        ent.ForEach(e => dbContext.Entitys.Add(e));
        dbContext.SaveChanges();
    }
