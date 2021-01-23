    public class XVariant
    {
        public readonly XElement self;
        public XVariant(XElement element = null) 
        { 
            self = element ?? new XElement("variant");
        }
    
        public int CharConfidence
        {
            get { return (int)self.Attribute("charConfidence"); }
            set
            {
                XAttribute cc = self.Attribute("charConfidence");
                if (cc == null)
                    self.Add(cc = new XAttribute("charConfidence"));
                cc.Value = value.ToString();
            }
        }
    
        public string Value
        {
            get { return self.Value; }
            set { self.Value = value; }
        }
    }
