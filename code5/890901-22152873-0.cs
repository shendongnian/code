    public OtherClass fileName(string rate)
    {
        OtherClass obj = new OtherClass();
        if (rate == "2013")
        {
            obj.xmlName = "abc";
            obj.xsdName = "def";
        }
        if (rate == "2014")
        {
            obj.xmlName = "pqr";
            obj.xsdName = "xyz";
        }
        return obj;
    }
    public class OtherClass
    {
        public string xmlName { get; set; }
        public string xsdName { get; set; }
    }
