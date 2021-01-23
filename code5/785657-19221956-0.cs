    XDocument doc = XDocument.Load(@"D:\\path.xml");
            //Run Query
            var gnrl = from general in doc.Descendants("general")
                       select new {
                           parent = general.Attribute("name").Value,
                           child = general.Descendants("service")
                       };
            var parentNode = dcselectview.Nodes.Add(general.ToString());
            //Loop through results
            foreach (var general in gnrl)
            {
                foreach (var ser in general.child)          
                    parentNode.Nodes.Add(ser.ToString());
            }
