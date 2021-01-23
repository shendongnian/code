    internal void Load(List<IEntityWrapper> collection, MergeOption mergeOption)
    {
        bool flag;
        ObjectQuery<TEntity> query = base.ValidateLoad<TEntity>(mergeOption, "EntityCollection", out flag);
        base._suppressEvents = true;
        try
        {
            if (collection == null)
            {
                base.Merge<TEntity>(flag ? RelatedEnd.GetResults<TEntity>(query) : Enumerable.Empty<TEntity>(), mergeOption, true);
            }
            else
            {
                base.Merge<TEntity>(collection, mergeOption, true);
            }
        }
        finally
        {
            base._suppressEvents = false;
        }
        this.OnAssociationChanged(CollectionChangeAction.Refresh, null);
    }
