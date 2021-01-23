        using (ISession session = SessionFactory.OpenSession())
        {
            List<User.PublishedInfo> results = null;
            ITransaction transaction = null;
            try
            {
                transaction = session.BeginTransaction();
                results = session.CreateCriteria<User>()
                    .SetProjection(PublishedUserProjections)
                    .AddOrder(Order.Desc("XP"))
                    .SetMaxResults(count)
                    .SetResultTransformer(Transformers.AliasToBean<User.PublishedInfo>())
                    .List<User.PublishedInfo>();
    
                foreach (var r in results)
                    r.Initialize();
    
                transaction.Commit();
            }
            catch(Exceptionn ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
            return results;
        }
