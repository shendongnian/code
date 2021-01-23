    public class Global : System.Web.HttpApplication
    {
    
        protected void Application_Start(object sender, EventArgs e)
        {
            SessionFactory = Fluently.Configure()
                                     .Database(
                                        SQLiteConfiguration.Standard
                                            .UsingFile("firstProject.db")
                                     )
                                     .BuildSessionFactory();
        }
    
        protected void Session_Start(object sender, EventArgs e)
        {
    
        }
    
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }
    
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();
        }
    
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }
        protected void Application_Error(object sender, EventArgs e)
        {
        }
        protected void Session_End(object sender, EventArgs e)
        {
        }
        protected void Application_End(object sender, EventArgs e)
        {
        }
    
        public static ISessionFactory SessionFactory
        {
            get;
            private set;
        }
    }
