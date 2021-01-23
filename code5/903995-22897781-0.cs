    protected bool IsLoaded<TEntity>(TEntity entity, Func<TEntity, object> testAction)
    {
        try
        {
            testAction(entity);
            return true;
        }
        catch (ObjectDisposedException)
        {
            return false;
        }
    }
