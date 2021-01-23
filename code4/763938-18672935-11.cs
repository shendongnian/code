        public void Delete(T entity)
        {
            var castedEntity = entity as Entity;
            if (castedEntity != null)
            {
                castedEntity.IsDeleted = true;
            }
            else
            {
                _context.Remove(entity);
            }            
        }
