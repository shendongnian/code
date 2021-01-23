    public class DBRewriteModule : IHttpModule
    {
        public DBRewriteModule()
        {
            
        }
        public void Init(HttpApplication context)
        {
            context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);
        }
        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            Rewriter rw = new Rewriter();
            rw.Process();
        }
    }
