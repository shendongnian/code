    class Program
    {
        static void Main(string[] args)
        {
            XDocument file = XDocument.Load(@"C:\test.xml");
            var query = file.Element("UserInfo").Element("User").Element("ID").Value;
            Console.WriteLine(query);
            Console.ReadKey();
        }
    }
