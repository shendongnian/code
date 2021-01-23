            // using XPath
            var doc = new XmlDocument();
            doc.LoadXml(XML);
            var subtype2 = doc.SelectNodes("/Toplevels/TopLevel/Level1/Subtype");
            Console.WriteLine("XPath Level1 Subtype");
            foreach (XmlNode el in subtype2)
            {
                Console.WriteLine(el.InnerText);    
            }
            // using XPath shorter, less efficient
            var subtype3 = doc.SelectNodes("//Level1/Subtype");
            Console.WriteLine("XPath Level1 Subtype");
            foreach (XmlNode el in subtype3)
            {
                Console.WriteLine(el.InnerText);
            }
