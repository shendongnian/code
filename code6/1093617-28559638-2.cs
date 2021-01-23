    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("XMLFile1.xml");
            Console.WriteLine("Before:");
            Console.WriteLine();
            Console.WriteLine(doc.ToString());
            foreach(var valueNode in doc.Descendants("data").SelectMany(n=> n.Elements("value")))
            {
                valueNode.Value = string.Empty;
            }
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("After:");
            Console.WriteLine();
            Console.WriteLine(doc.ToString());
        }
    }
    
