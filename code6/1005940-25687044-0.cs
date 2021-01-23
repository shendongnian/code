    namespace ConsoleApplication3
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.Linq;
        using System.Net;
        using System.Text;
        using System.Threading.Tasks;
        using System.Xml.Linq;
    
     public class Config
            {
                public string Name { get; set; }
                public string Version { get; set; }
                public string SubFolder { get; set; }
            }
    
        public class Component
        {
            public List<Config> SystemConfig;
            public string Name { get; set; }
            public string Version { get; set; }
            public string Enabled { get; set; }
            public Component()
            {
    
                this.SystemConfig = new List<Config>();
            }
        }
    
        public class Program
        {
    
            public static void Main()
            {
                XDocument xmlDocument = XDocument.Load(@"c:\Visual Studio\Projects\ConsoleApplication3\ConsoleApplication3\config.xml");
                var item = (from template in xmlDocument.Descendants("Component")
                            where template.Parent.Attribute("Name").Value.Equals("Host1", StringComparison.CurrentCultureIgnoreCase)
                            select new Component()
                            {
                                Version = template.Attribute("Version").Value,
                                Name = template.Attribute("Name").Value,
                                Enabled = template.Attribute("Enabled").Value,
                                SystemConfig = (
                                   from t in template.Elements("Config")
                                   select new Config()
                                   {
                                       Name = t.Attribute("Name").Value,
                                       SubFolder = t.Attribute("SubFolder").Value,
                                       Version = t.Attribute("Version").Value
                                   }
                                   ).ToList()
                            }
                                     ).FirstOrDefault();
            }
        }
    }
