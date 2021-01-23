    public class ConnectionElement : ConfigurationElement
    {
         [ConfigurationProperty("uri", DefaultValue = "/")]
         public string Uri
         {
             get { return (string) this["uri"]; }
             set { this["uri"] = value; }
         }
    }
