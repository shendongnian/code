    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("XMLFile1.xml");
            
            foreach(var valueNode in doc.Descendants("data").SelectMany(n=> n.Elements("value")))
            {
                valueNode.Value = string.Empty;
            }            
        }
    }
    
