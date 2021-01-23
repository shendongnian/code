    public class ConnectionElement : ConfigurationElement
    {
         [ConfigurationProperty("uri", DefaultValue = "/")]
         public String Uri
         {
             get { return (String)this["uri"]; }            
             set { this["uri"] = value; }
         }
     }
