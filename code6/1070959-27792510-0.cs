    public class Global : System.Web.HttpApplication
    {
        //Register your routes, match a custom URL with an .aspx file. 
        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("About", "about", "~/about.aspx");
            routes.MapPageRoute("Index", "index", "~/index.aspx");
        }
        //Init your new route table inside the App_Start event.
        protected void Application_Start(object sender, EventArgs e)
        {
            this.RegisterRoutes(RouteTable.Routes);
        } 
    }   
