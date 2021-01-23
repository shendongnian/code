    public virtual async Task SaveAndCommitAsync(TEntity entity)
    {
        try
        {
            Save(entity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (DbEntityValidationException e)
        {
        }
    }
