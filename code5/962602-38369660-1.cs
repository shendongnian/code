    var hostWeb = Page.Request["SPHostUrl"];
    using (var clientContext = new ClientContext(hostWeb))
    {
        clientContext.ExecutingWebRequest += new EventHandler<WebRequestEventArgs>(clientContext_ExecutingWebRequest);
        clientContext.Load(clientContext.Web, web => web.Title);
        clientContext.ExecuteQuery();
        Response.Write(clientContext.Web.Title);
    }
    static void clientContext_ExecutingWebRequest(object sender, WebRequestEventArgs e)
    {
        e.WebRequestExecutor.WebRequest.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
    }
