    public class Global : System.Web.HttpApplication
    {    
        public static ISessionFactory SessionFactory { get; private set; }	
	
        protected void Application_Start(object sender, EventArgs e)
        {
			// Create a session factory when the application starts.
			// Session factories are expensive to create, and therefore you should create one and use it throughout your application.
            SessionFactory = Fluently.Configure()
                                     .Database(
                                        SQLiteConfiguration.Standard
                                            .UsingFile("firstProject.db")
                                     )
                                     .BuildSessionFactory();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
			// Create a session per request.
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }
    
        protected void Application_EndRequest(object sender, EventArgs e)
        {
			// Close the session at the end of every request
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();
        }
        protected void Application_End(object sender, EventArgs e)
        {
			// Close the session factory at the end of the application.
			if (SessionFactory != null)
				SessionFactory.Dispose();
        }
    }
