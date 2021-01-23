    public class MyClass 
    {
        [XmlElement(Namespace = "http://www.example1.com")]
        public string sample1;
        [XmlElement(Namespace = "http://www.example2.com")]
        public string sample2;
    
        //....
    }
   
    //...
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("prefix", "http://www.example2.com");
