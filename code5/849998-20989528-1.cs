     public class CustomSection : ConfigurationSection
     {
       public CustomSecuritySection Security { get; private set; }
                    [ConfigurationProperty("type", IsRequired = true, DefaultValue = "QueryStringModule")]
          public String type
           {
             get { return (String)base["type"]; }
             set { base["type"] = value; }
            }
        
           [ConfigurationProperty("name", IsRequired = true, DefaultValue = "QueryStringModule")]
      public String name
       {
         get { return (String)base["name"]; }
         set { base["name"] = value; }
        }
        
       //public CustomSection()
       //{
        
        //}
       }                
             
        
         
--------------------
    CustomSection obj = new CustomSection();
            Configuration config = ConfigurationManager.OpenExeConfiguration(@"D:\xxxxx\xxxx\web.config");
            //var httpmod = config.Sections.Add("TestSecton", 
            config.Sections.Add("HttpModule", obj);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("HttpModule");
