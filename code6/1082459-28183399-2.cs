    class Program
    {
        static void Main(string[] args)
        {
            XElement x = XElement.Load("XMLFile1.xml");
            recursive(x.Elements());
            Console.ReadKey();
        }
        private static void recursive(IEnumerable<XElement> elements)
        {
            foreach (XElement n in elements)
            {
                Console.WriteLine(n.Name);
                Console.WriteLine("--");
                if (n.Descendants().Any())
                {
                    recursive(n.Elements());
                }
                else
                {
                 Console.WriteLine(n.Value.ToString());// End of node (leaf)
                }
            }
        }
    }
