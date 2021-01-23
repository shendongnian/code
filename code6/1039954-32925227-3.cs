    protected void Application_BeginRequest(object sender, EventArgs e)
    {
    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin" , "*");
    if (HttpContext.Current.Request.HttpMethod == "OPTIONS" )
    {    
    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods" , "GET, POST" );
    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Authorization, Origin, Content-Type, Accept, X-Requested-With");
    HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000" );
    HttpContext.Current.Response.End();
    }
    }
