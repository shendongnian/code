    public class UserUrlRewriteModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.context_BeginRequest);
        }
        private void context_BeginRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            var user = context.User;
            if (user != null && user.Identity.IsAuthenticated)
                context.Response.Redirect(context.Request.Url.AbsoluteUri + "?id=" + user.Name);
        }
    }
