     protected void Application_BeginRequest()
            {
                if (!Settings.Data.Valid())
                    return;
    
                var session = SessionManager.SessionFactory.OpenSession();
                if (!session.Transaction.IsActive)
                    session.BeginTransaction(IsolationLevel.ReadCommitted);
                CurrentSessionContext.Bind(session);
            }
