    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetManifestTokenResolver(new ManifestTokenResolver());
        }
    }
    
    public class ManifestTokenResolver : IManifestTokenResolver
    {
        public string ResolveManifestToken(DbConnection connection)
        {
            // The simplest thing is just to return hardcoded value
            // return "2012";
    
            try
            {
                connection.Open();
    
                var majorVersion =
                    Int32.Parse(connection.ServerVersion.Substring(0, 2), CultureInfo.InvariantCulture);
    
                if (majorVersion == 9)
                {
                    return "2005";
                }
    
                if (majorVersion == 10)
                {
                   return "2008";
                }
                
                return "2012";
            }
            finally 
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
