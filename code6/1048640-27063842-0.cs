            StreamReader read = new StreamReader("FilePath.xml");
            XDocument xDoc = XDocument.Load(XmlReader.Create(read));
            List<string> docList = new List<string>();
            var root = xDoc.Element("ROOT");
            foreach (var element in root.Elements("DOC"))
            {
                string s = element.Value;
                docList.Add(s);
            }
