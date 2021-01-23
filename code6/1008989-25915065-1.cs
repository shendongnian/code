    public override void CombineDeletedEntities()
    {
        if (this.deletedEntities != null && this.deletedEntities.Count > 0)
        {
            foreach (T entity in deletedEntities)
            {
                entities.Add(entity);
            }
                
            this.deletedEntities.Clear();
        }
    }
