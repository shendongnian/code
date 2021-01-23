    using (ServerManager serverManager = new ServerManager())
    {
         Configuration config = serverManager.GetWebConfiguration(); // or set application name 
    
         ConfigurationSection rulesSection = config.GetSection("system.webServer/rewrite/rules");
         ConfigurationElementCollection rulesCollection = rulesSection.GetCollection();
    
         foreach (var r in rulesCollection)
         {
             foreach (var c in r.ChildElements)
             {
                foreach (var a in c.Attributes)
                    Response.Write(a.Name + "=" + a.Value);
             }
         }
    }
