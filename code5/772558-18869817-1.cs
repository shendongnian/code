    public void Init(HttpApplication context)
    {
        context.BeginRequest += new EventHandler(context_BeginRequest);
        context.EndRequest += new EventHandler(context_EndRequest);
        context.AcquireRequestState += new EventHandler(SessionClear);
    }
    public void SessionClear(object sender, EventArgs e)
    {
        try
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                if (!(HttpContext.Current.Session.Keys.Count > 0))
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
