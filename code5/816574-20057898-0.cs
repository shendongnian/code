    void Application_Error(object sender, EventArgs e)
    {
      // Code that runs when an unhandled error occurs
    
      Response.TrySkipIisCustomErrors = true;
      this.Server.ClearError();
      this.Server.GetLastError();
    
      //Option 1:
      Response.Write("Error");
        
      //Option 2:
      Response.Redirect("~/Error.aspx");
      //Option 3:
      this.Server.Transfer("~/Error.aspx");
    }
