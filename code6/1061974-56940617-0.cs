    protected void Application_BeginRequest()
    {
      if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
      {
        Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44343");
        Response.Headers.Add("Access-Control-Allow-Headers",
          "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");
        Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        Response.Headers.Add("Access-Control-Allow-Credentials", "true");
        Response.Flush();
      }
    }
  
