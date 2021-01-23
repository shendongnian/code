        static void Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"c:\test.xml");
            XmlNodeList xNodes = xdoc.DocumentElement.SelectNodes("pit");
            Console.WriteLine("Num: " + xNodes.Count.ToString());
            foreach (XmlNode dStr in xNodes)
            {
                Console.WriteLine("Name: " + dStr.SelectSingleNode("name").InnerText);
                Console.WriteLine("ip: " + dStr.SelectSingleNode("ip").InnerText);
                Console.WriteLine("ratio: " + dStr.SelectSingleNode("ratio").InnerText);
                Console.WriteLine("X: " + dStr.SelectSingleNode("z").InnerText);
                Console.WriteLine("Y: " + dStr.SelectSingleNode("y").InnerText);
                Console.WriteLine("X: " + dStr.SelectSingleNode("x").InnerText);
            }
            Console.Read();
        }
