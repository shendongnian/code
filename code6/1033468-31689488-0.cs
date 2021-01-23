    var sessionBinding = Bind<ISession>().ToMethod(ctx =>
    {
    	var session = ctx.Kernel.Get<INHibernateSessionFactoryBuilder>()
    		.GetSessionFactory()
    		.OpenSession();
    	return session;
    });
    
    if (this.SingleSession)
    	sessionBinding.InSingletonScope();
    else if (this.WebSession)
    	sessionBinding.InRequestScope();
    else
    	sessionBinding.InScope(ScreenScope);
