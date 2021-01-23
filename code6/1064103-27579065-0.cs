     public TEntity Update(TEntity entity)
            {
                Entities.Add(entity);
                DataContext.Entry(entity).State = EntityState.Modified;
                return entity;
            }
