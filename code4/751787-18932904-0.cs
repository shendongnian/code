     public bool RuleExists(string source, string destination)
    {
        XDocument doc = XDocument.Load(Path.Combine(Server.MapPath("~").ToString(), "web.config"));
        return doc.Descendants("rewriteRules").Elements()
                  .Where(e => e.Attribute("source").Value == source
                  && e.Attribute("destination").Value == destination).Any();
    }
    public void DefineUrlRewrite(string source, string destination)
    {
        XDocument xml = XDocument.Load(Path.Combine(Server.MapPath("~").ToString(), "web.config"));
        if (RuleExists(source, destination))
        {
            //element is already in the config file
            //do something...
            lblMsg.Text = "This Rule is already exists, choose another one!!! <br/>";
        }
        else
        {
            XElement elem = new XElement("rule");
            elem.SetAttributeValue("source", source);
            elem.SetAttributeValue("destination", destination);
            xml.Descendants("rewriteRules").First().Add(elem);
            xml.Save(Path.Combine(Server.MapPath("~").ToString(), "web.config"));
        }
    }
