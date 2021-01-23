        public static T FromXml<T>(this IEnumerable<XmlNode> input)
        {
            T output;
            var type = typeof(T);
            XmlSerializer serializer = CreateSerializer(type);
            var doc = new XmlDocument();
            var rootAttribute = (XmlRootAttribute)type.GetCustomAttributes(true).Where(a => a is XmlRootAttribute).SingleOrDefault();
            string ns = null;
            if (rootAttribute != null)
            {
                ns = rootAttribute.Namespace;
            }
            doc.AppendChild(doc.CreateElement(type.Name, ns));
            foreach (var node in input)
            {
                if (node.Name != "type" && node.NamespaceURI != "http://www.w3.org/2001/XMLSchema-instance")
                {
                    var inode = doc.ImportNode(node, true);
                    if (inode is XmlAttribute)
                    {
                        doc.DocumentElement.Attributes.Append((XmlAttribute)inode);
                    }
                    else
                    {
                        doc.DocumentElement.AppendChild(inode);
                    }
                }
            }
            output = (T)serializer.Deserialize(new StringReader(doc.OuterXml));
            return output;
        }
