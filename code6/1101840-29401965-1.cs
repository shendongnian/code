    private ISession CreateSession(IServiceFactory factory)
    {
        var sessionFactory = factory.GetInstance<ISessionFactory>();
        if (!CurrentSessionContext.HasBind(sessionFactory))
        {
            var session = sessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }
        return sessionFactory.GetCurrentSession();
    }
