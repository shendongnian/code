     public static class XmlDocumentExtension
    {
        public static dynamic ToObject(this XmlDocument document)
        {
            XmlElement root = document.DocumentElement;
            return ToObject(root, new ExpandoObject());
        }
        private static dynamic ToObject(XmlNode node, ExpandoObject config, int count = 1)
        {
            var parent = config as IDictionary<string, object>;
            foreach (XmlAttribute nodeAttribute in node.Attributes)
            {
                var nodeAttrName = nodeAttribute.Name.ToString();
                parent[nodeAttrName] = nodeAttribute.Value;
            }
            foreach (XmlNode nodeChild in node.ChildNodes)
            {
                if (IsTextOrCDataSection(nodeChild))
                {
                    parent["Value"] = nodeChild.Value;
                }
                else
                {
                    string nodeChildName = nodeChild.Name.ToString();
                    if (parent.ContainsKey(nodeChildName))
                    {
                        parent[nodeChildName + "_" + count] = ToObject(nodeChild, new ExpandoObject(), count++);
                    }
                    else
                    {
                        parent[nodeChildName] = ToObject(nodeChild, new ExpandoObject());
                    }
                }
            }
            return config;
        }
        private static bool IsTextOrCDataSection(XmlNode node)
        {
            return node.Name == "#text" || node.Name == "#cdata-section";
        }
    }
