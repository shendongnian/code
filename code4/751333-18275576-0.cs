    public static bool RuleExists(string source, string destination)
    {
         XDocument doc = XDocument.Load(HttpContext.Current
                                  .Server.MapPath("your file"));
         return doc.Descendants("rewriteRules").Elements()
                   .Where(e => e.Attribute("source").Value == source 
                   && e.Attribute("destination").Value == destination).Any();
    }
