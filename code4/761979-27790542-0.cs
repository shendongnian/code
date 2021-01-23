    public void Init(HttpApplication objApplication)
    {
        objApplication.PreRequestHandlerExecute += new EventHandler(this.Application_PreRequestHandlerExecute);
    }
    private void Application_PreRequestHandlerExecute(object objSender, EventArgs objE)
    {
        Page objPage = (Page)(objSender as HttpApplication).Context.Handler; 
        objPage.AutoEventWireup = true;
    }
