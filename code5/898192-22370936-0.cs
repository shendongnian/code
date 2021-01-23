        static void Main(string[] args)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load("Models.xml");
            var result = from XmlNode row in xd.DocumentElement.SelectNodes("//Model[starts-with(@DESC, 'VOLKS') and @Status='out']") where row != null select row;
            foreach (var x in result)
            {
                XmlAttributeCollection attributes = x.Attributes;
                Console.Write("<Model ");
                foreach (XmlAttribute attribute in x.Attributes)
                {
                    Console.Write("{0}=\"{1}\"  ", attribute.Name, attribute.Value);
                }
                Console.WriteLine(" />");
            }
        }
