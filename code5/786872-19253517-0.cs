            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("root");
            XElement xmlEntry = new XElement("file",
               new XAttribute("name", "Example"),
               new XAttribute("hashcode", "Hashcode Example with some long string")
            );
            xmlRoot.Add(xmlEntry);
            xmlDoc.Add(xmlRoot);
            xmlDoc.Save("temp.xml");
            Console.WriteLine(System.IO.File.ReadAllText("temp.xml"));
