    public class ConnectionElement : ConfigurationElement
    {
         [ConfigurationProperty("uri", DefaultValue = "/")]
         public String Uri
         {
             get { return (String)this["Uri"]; }            
             set { this["Uri"] = value; }
         }
     }
