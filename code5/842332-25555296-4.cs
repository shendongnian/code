        public Dictionary<string, object> Deserialize(string OutPath) {
            Dictionary<string, object> Output = new Dictionary<string, object>();
            
            //create the xmlDocument
            XmlDocument xd = new XmlDocument();
            xd.Load(XmlReader.Create(OutPath));
            //Scan all the nodes in the main doc and add them to the dictionary
            //you can recursively check child nodes if your document requires.
            foreach (XmlNode node in xd.DocumentElement) {
                Output.Add(node.Name, node.InnerText);
            }
            return Output;
        }
