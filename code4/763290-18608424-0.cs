    public class ProductAttribute
    {
        public string Flag { get; set; }
        public string Sect { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Extrainfo { get; set; }
        
        public ProductAttribute(XElement xElement){
            Flag = (string)element.Attribute("flag");
            Sect = (string)element.Attribute("sect").Value;
            Header = (string)element.Attribute("header ").Value;
            Body = (string)element.Attribute("body").Value;
            Extrainfo = (string)element.Attribute("extrainfo").Value;
        }
    }
