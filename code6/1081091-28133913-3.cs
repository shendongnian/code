    public virtual void SaveAndCommitAsync(TEntity entity)
    {
        try
        {
            Save(entity);
            _unitOfWork.SaveChangesAsync();
        }
        catch (DbEntityValidationException e)
        {
        }
    }
