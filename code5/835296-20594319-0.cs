    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument xdoc = XDocument.Load("test.xml");
                XNamespace dns = "http://schemas.microsoft.com/ado/2007/08/dataservices";
                var elements = xdoc.Root.Elements().ToList();
                var elementsRes = xdoc.Root.Elements(dns+"element").Select((elt) => new PropertyKeyRef { PropertyName = elt.Element(dns+"DecisionKey").Value.ToString(),PropertyValue = elt.Element(dns+"DecisionText").Value.ToString() }).ToList();
                foreach (var item in elementsRes)
                {
                    //your code for the result  
                }
                   
    
            }
        }
        public  class PropertyKeyRef
        {
            public string PropertyName
            { get; set;  }
            public string PropertyValue
            { get; set; }
        }
    }
