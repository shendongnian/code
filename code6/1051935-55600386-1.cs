        internal static string SerializeObject(object objectToSerialize, bool OmitXmlDeclaration = true, System.Type type = null, bool OmitType = false, bool RemoveAllNamespaces = true)
        {
            XmlSerializer x;
            string output;
            if (type != null)
            {
                x = new XmlSerializer(type);
            }
            else
            {
                x = new XmlSerializer(objectToSerialize.GetType());
            }
            
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = false, OmitXmlDeclaration = OmitXmlDeclaration, NamespaceHandling = NamespaceHandling.OmitDuplicates };
            using (StringWriter swriter = new StringWriter())
            using (XmlWriter xmlwriter = XmlWriter.Create(swriter, settings))
            {
                x.Serialize(xmlwriter, objectToSerialize);
                output = swriter.ToString();
            }
            if (RemoveAllNamespaces || OmitType)
            {
                XDocument doc = XDocument.Parse(output);
                if (RemoveAllNamespaces)
                {
                    foreach (var element in doc.Root.DescendantsAndSelf())
                    {
                        element.Name = element.Name.LocalName;
                        element.ReplaceAttributes(GetAttributesWithoutNamespace(element));
                    }
                }
                if (OmitType)
                {
                    foreach (var node in doc.Descendants().Where(e => e.Attribute("type") != null))
                    {
                        node.Attribute("type").Remove();
                    }
                }
                output = doc.ToString();
            }
            return output;
        }
