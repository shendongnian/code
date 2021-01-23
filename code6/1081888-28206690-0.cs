            protected string Map(TransformBase map, string xml, string extObjects = null)
            {
                string result = string.Empty;
                XslCompiledTransform transform = new XslCompiledTransform();
                XsltSettings setting = new XsltSettings(false, true);
                transform.Load(XmlReader.Create(new StringReader(map.XmlContent)), setting, new XmlUrlResolver());
    
                using (StringWriter writer = new StringWriter())
                {
                    transform.Transform(XmlReader.Create(new StringReader(xml)),
                    GetExtensionObjects(extObjects), XmlWriter.Create(writer));
                    result = writer.ToString();
                }
    
                return result;
            }
    
            protected XsltArgumentList GetExtensionObjects(string extObjects)
            {
                XsltArgumentList arguments = new XsltArgumentList();
                if (extObjects == null)
                    return arguments;
    
                XDocument extObjectsXDoc = XDocument.Parse(extObjects);
                foreach (XElement node in extObjectsXDoc.Descendants("ExtensionObject"))
                {
                    string assembly_qualified_name = String.Format("{0}, {1}", node.Attribute("ClassName").Value, node.Attribute("AssemblyName").Value);
                    object extension_object = Activator.CreateInstance(Type.GetType(assembly_qualified_name));
                    arguments.AddExtensionObject(node.Attribute("Namespace").Value, extension_object);
                }
                return arguments;
            }
