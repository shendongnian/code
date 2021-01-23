    public class ConnectionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }
        private void OnEndRequest(object sender, EventArgs e)
        {
            var db = ((HttpApplication)sender).Context.Items["DbConnection"] as IDbConnection;
            if (db != null)
                db.Dispose();
        }
        private void OnBeginRequest(object sender, EventArgs e)
        {
            var conString = ConfigurationManager.ConnectionStrings["Master"].ConnectionString;
            var connection = new SqlConnection(conString);
            connection.Open();
            ((HttpApplication)sender).Context.Items["DbConnection"] = connection;
        }
        public void Dispose()
        {
        }
    }
