    public void UpdateMyNHiberateEntity(MyNHiberateEntity item)
    {
        using (ISession session = ISessionCreator.OpenSession()) /* You won't have this method probably, but your code will create a new ISession here */
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.BeginTransaction();
                MyNHiberateEntity mergedItem = session.Merge(item);
                transaction.Commit();
            }
        }
    }
