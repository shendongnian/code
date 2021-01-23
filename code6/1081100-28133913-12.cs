    public virtual async Task SaveAndCommitWithTransactionAsync(TEntity entity)
    {
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
                Save(entity);
                await _unitOfWork.SaveChangesAsync();
                transaction.Commit();
            }
            catch (DbEntityValidationException e)
            {
                transaction.Rollback();
            }
        }
    }
