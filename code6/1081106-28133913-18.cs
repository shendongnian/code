        public virtual Task SaveAndCommitAsync(TEntity entity)
        {
           try
           {
               Save(entity);
               return _unitOfWork.SaveChangesAsync();
           }
           catch (DbEntityValidationException e)
           {
           }
        }
