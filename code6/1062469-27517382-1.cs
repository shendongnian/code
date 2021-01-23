    public class A
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Document { get; set; }
    public static dynamic Get A()
    {
    var allVariables= (from f in doc.Elements("Features").Elements("Feature")
                           select new A
                           {
                               Date=(f.Parent.Attribute("date") == null) ? "NA" : f.Parent.Attribute("date").Value,
                               Name = f.Attribute("name").Value,
                               Description = f.Value,
                               Link = f.Attribute("Ticket").Value,
                               Document = (f.Attribute("Document") != null) ? f.Attribute("Document").Value : null
                           });
    return allVariables;
    }
    }
    public class B
    {
        public string Fixes { get; set; }
        public string Date { get; set; }
        public string Link { get; set; }ynamig
        public string Document { get; set; }
    public static dynamic getB()
    {
    var allVars= (from p in doc.Elements("Patches").Elements("Patch").Elements("Fix")
                          select new B
                          {
                              Fixes = p.Value,
                              Date = (p.Parent.Attribute("date") == null) ? "NA" : p.Parent.Attribute("date").Value,
                              Link = (p.Attribute("Ticket") == null) ? "" : p.Attribute("Ticket").Value,
                              Document = (p.Attribute("Document") != null) ? p.Attribute("Document").Value : ""
                          }
                              );
    return allVars;
    }
    }
