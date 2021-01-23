    public class RequestLoggingModule : IHttpModule
    {
        private HttpApplication httpApp;
        public void Init(HttpApplication httpApp)
        {
            this.httpApp = httpApp;
            httpApp.BeginRequest += new EventHandler(OnBeginRequest);
        }
        void OnBeginRequest(object sender, EventArgs e)
        {
            // Get the user that made the request
            HttpApplication application = (HttpApplication)sender;
            HttpResponse response = application.Context.Response;
            WindowsIdentity identity = 
               (WindowsIdentity)application.Context.User.Identity;
            LogInformation(identity.Name);
            // Do this for other information you want to log here
        }
        private void LogInformation(string data)
        {
            EventLog log = new EventLog();
            log.Source = "Application XYZ Request Logging";
            log.WriteEntry(data, EventLogEntryType.Information);
        }
        public void Dispose()
        {
        
        }
    }
