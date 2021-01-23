    public static ISession GetCurrentSession()
    {
        HttpContext context = HttpContext.Current;
        ISession currentSession = context.Items[CurrentSessionKey] as ISession;
        if (currentSession == null)
        {
            currentSession = sessionFactory.OpenSession();
            context.Items[CurrentSessionKey] = currentSession;
        }
        return currentSession;
    }
