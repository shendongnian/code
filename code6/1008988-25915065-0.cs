    public override void CombineDeletedEntities()
    {
        if (this.deletedEntities != null && this.deletedEntities.Count > 0)
        {
            foreach (T entity in deletedEntities)
            {
                entities.Add(entity);
            }
        }
    }
    public override void SeparateDeletedEntities()
    {
        foreach (T entity in this.entities)
        {
            if (entity.rowState == esDataRowState.Deleted)
            {
                if (deletedEntities == null)
                {
                    deletedEntities = new BindingList<T>();
                }
                deletedEntities.Add(entity);
            }
        }
        if (this.deletedEntities != null && this.deletedEntities.Count > 0)
        {
            foreach (T entity in deletedEntities)
            {
                entities.Remove(entity);
            }
        }
    }
