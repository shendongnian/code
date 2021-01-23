        protected void Application_Error(object sender, EventArgs e)
        {
            // capture the exception beforehand  if you need to
            var exception = Server.GetLastError();
            // Tell the server we're handling the error "our way"
            Server.ClearError();
            ...
            // You may also need to reset the response type
            Context.Response.ContentType = "text/html";
            controller.Execute(new RequestContext(new HttpContextWrapper(context), routeData));
        }
