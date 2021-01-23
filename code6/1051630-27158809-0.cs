    public static class YourFactory
    {
       public static SqlConnection GetConnection()
       {
          string connStr = System.Configuration.ConfigurationManager
                              .ConnectionStrings["MyConnectionString"].ConnectionString;
          return new SqlConnection(connStr);
       }
    
       public static PrincipalContext GetPrincipalContext()
       {
            string user, pass, domain;
            domain = ConfigurationManager.AppSettings["SAdomain"];
            user = ConfigurationManager.AppSettings["SAuser"];
            pass = ConfigurationManager.AppSettings["SApass"];
    
            return new PrincipalContext(ContextType.Domain, domain + ".mydomain.ca",
                     "CN=MyCN,DC=myDC,DC=ca", user, pass);
        }
    }
