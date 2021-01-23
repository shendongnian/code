    <configuration>
      ...
      <system.webServer>
        <handlers>
          <!-- Make sure to update the namespace "WebApplication1.Blog" to whatever your namespace is-->
          <add name="MetaWebLogHandler" verb="POST,GET" type="WebApplication1.Blog.MetaWeblogHandler" path="/XmlRpc" />
        </handlers>
      </system.webServer>
    </configuration>
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        //Make sure MVC ignores /XmlRpc, which will be directly handled by MetaWeblogHandler
        routes.IgnoreRoute("XmlRpc");
        ... your other routes ...         
    }
