        protected void Application_Error(Object sender, EventArgs e)
		{
             Exception ex = this.Server.GetLastError();
             if(ex is HttpException)
             {
                  HttpException httpEx = (HttpException)ex;
                  if(httpEx.GetHhttpCode() == 401)
                  {
                       Response.Redirect("YourPage.aspx");
                  }
             }
        }
