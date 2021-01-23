    string targetUrl = Request.QueryString["redirect"];
    string serverUrlPath = Server.MapPath(targetUrl);
    string serverDirPath = Server.MapPath("~/ErrorPages");
    
    foreach (string file in Directory.EnumerateFiles(serverDirPath))
    {
      if (file.Equals(serverUrlPath, StringComparison.OrdinalIgnoreCase))
      {
        Response.Redirect(Master.ProjectSearchRedirect());
      }
    }
    Response.Redirect(targetUrl);
