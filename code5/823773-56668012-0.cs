    private void RefreshData(DBEntity entity)
    {
        if (entity == null) return;
        ((IObjectContextAdapter)DbContext).ObjectContext.RefreshAsync(RefreshMode.StoreWins, entity);
    }
    private void RefreshData(List<DBEntity> entities)
    {
        if (entities == null || entities.Count == 0) return;
        ((IObjectContextAdapter)DbContext).ObjectContext.RefreshAsync(RefreshMode.StoreWins, entities);
    }
