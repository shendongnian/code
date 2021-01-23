    private static void XmlOutput()
        {
            var filePathAndName = @"http://api.openweathermap.org/data/2.5/forecast?q=lahti,fin&mode=xml";
            var xmlDoc = XDocument.Load(filePathAndName);
            // Get list of Nodes matching the "time" name or any other filters you wish.
            var nodes = xmlDoc.Descendants().Where(nd => nd.Name.LocalName == "time");
            // Filter the node list to only those where the date is as specified (and any other filters you wish).
            // This could be done in the initial linq query - just making it clearer here.
            nodes = nodes.Where(nd => nd.Attributes().Any(cnd => cnd.Name.LocalName == "from" && cnd.Value.Contains("2015-03-07")));
            foreach (XElement element in nodes)
            {
                // For each descendant node where named "symbol"... 
                foreach(var node in element.Descendants().Where(nd => nd.Name.LocalName == "symbol"))
                {
                    // Write out these particular attributes ("number" and "name")
                    string output = "";
                    output += node.Attributes().FirstOrDefault(nd => nd.Name.LocalName == "number").Value;
                    output += ", " + node.Attributes().FirstOrDefault(nd => nd.Name.LocalName == "name").Value;
                    Console.WriteLine(output);
                }
            }
            Console.ReadKey();
        }
