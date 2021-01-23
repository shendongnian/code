    var dirtyObjects = new List<object>();
    var sessionImpl = hsession.GetSessionImplementation();
    foreach (NHibernate.Engine.EntityEntry entityEntry in sessionImpl.PersistenceContext.EntityEntries.Values)
    {
        var loadedState = entityEntry.LoadedState;
        var o = sessionImpl.PersistenceContext.GetEntity(entityEntry.EntityKey);
        var currentState = entityEntry.Persister.GetPropertyValues(o, sessionImpl.EntityMode);
        if (entityEntry.Persister.FindDirty(currentState, loadedState, o, sessionImpl) != null)
        {
            dirtyObjects.Add(entityEntry);
        }
    }
