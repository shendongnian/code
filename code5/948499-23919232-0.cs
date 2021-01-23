    Configuration webConfig = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath); 
    ConfigurationSection cs = webConfig.GetSection("system.webServer");
    if (cs != null)
    {
        XDocument xml = XDocument.Load(new StringReader(cs.SectionInformation.GetRawXml()));
        IEnumerable<XElement> rules = from c in xml.Descendants("rule") select c;
    
        foreach (XElement rule in rules)
        {
            Response.Write(Server.HtmlEncode(rule.ToString()));
        }
    }
