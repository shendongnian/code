    var entity = context.Entities
                        .AsNoTracking()
                        .Include(x => x.ChildEntities)
                        .FirstOrDefault(x => x.EntityId == entityId);
    
    entity.SomeProperty = DateTime.Now;
    
    context.Entities.Add(entity);
    context.SaveChanges();
