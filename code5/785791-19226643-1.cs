    public IList<T> GetList<T>(DetachedCriteria detachedCriteria)
    {
        IList<T> result;
        using (var session = Config.OpenSession())
        using (var txn = session.BeginTransaction())
        {
            result = detachedCriteria.GetExecutableCriteria(session).List<T>();
            txn.Commit();
        }
        return result;
    }
