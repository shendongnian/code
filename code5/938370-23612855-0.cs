    public class MvcApplication : System.Web.HttpApplication
    {
        public const string dbcontext = "Db.Context";
        public MvcApplication()
        {
            BeginRequest += MvcApplication_BeginRequest;
            EndRequest += MvcApplication_EndRequest;
        }
        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items[dbcontext] = new BlahContext();
        }
        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            var ctx = HttpContext.Current.Items[dbcontext] as BlahContext;
            if (ctx != null)
                try
                {
                    (ctx as IDisposable).Dispose();
                }
                catch (ObjectDisposedException)
                {
                    //yum
                }
        }
    }
