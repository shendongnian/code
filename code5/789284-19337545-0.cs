    public class Elbo
    {
        XElement self;
        public Elbo(XElement elbo) { self = elbo; }
    
        public string Name
        {
             get { return self.Element("Name").Value; }
             set 
             { 
                   XElement name = self.Element("Name");
                   if(null == name)
                        self.Add(name = new XElement("Name"));
                   name.Value = value;
             }
        }
    }
