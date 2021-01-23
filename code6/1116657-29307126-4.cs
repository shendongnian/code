    You can also adopt the hybrid approach and use `XmlSerializer` to deserialize and re-serialize known chunks of an `XmlDocument`.  Here are some (extension methods)[https://msdn.microsoft.com/en-us/library/bb383977.aspx] for this purpose -- *but since you're using c# 2.0, you **must** remove the `this` keyword*:
        public static class XmlNodeExtensions
        {
            public static XmlElement SerializeToXmlElement<T>(this T o, XmlElement parent)
            {
                return SerializeToXmlElement(o, parent, new XmlSerializer(o.GetType()));
            }
            public static XmlElement SerializeToXmlElement<T>(this T o, XmlElement parent, XmlSerializer serializer)
            {
                int oldCount = parent.ChildNodes.Count;
                XPathNavigator navigator = parent.CreateNavigator();
                using (XmlWriter writer = navigator.AppendChild())
                {
                    writer.WriteComment(""); // Kludge suggested here: https://social.msdn.microsoft.com/Forums/en-US/9ff20a3c-913d-4c6f-a18a-c10040290862/how-to-xmlserialize-directly-into-xmldocument?forum=asmxandxml
                    serializer.Serialize(writer, o);
                }
                XmlElement returnedElement = null;
                for (int i = parent.ChildNodes.Count - 1; i >= oldCount; i--)
                {
                    XmlComment comment = parent.ChildNodes[i] as XmlComment;
                    if (comment != null)
                    {
                        parent.RemoveChild(comment);
                    }
                    else
                    {
                        returnedElement = (parent.ChildNodes[i] as XmlElement) ?? returnedElement;
                    }
                }
                return returnedElement;
            }
            public static XmlDocument SerializeToXmlDocument<T>(this T o)
            {
                return SerializeToXmlDocument(o, new XmlSerializer(o.GetType()));
            }
            public static XmlDocument SerializeToXmlDocument<T>(this T o, XmlSerializer serializer)
            {
                XmlDocument doc = new XmlDocument();
                using (XmlWriter writer = doc.CreateNavigator().AppendChild())
                    serializer.Serialize(writer, o);
                return doc;
            }
            public static T Deserialize<T>(this XmlElement element)
            {
                return Deserialize<T>(element, new XmlSerializer(typeof(T)));
            }
            public static T Deserialize<T>(this XmlElement element, XmlSerializer serializer)
            {
                using (var reader = new XmlNodeReader(element))
                    return (T)serializer.Deserialize(reader);
            }
        }
    Given those methods, you can do things like:
            // Load the document from XML
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            // Find all nodes with name "Report"
            foreach (XmlElement reportNode in doc.SelectNodes("/RootXml/Report"))
            {
                // Deserialize as a Report
                Report report = XmlNodeExtensions.Deserialize<Report>(reportNode);
                // Do something with it 
                // Create a new Report, based on the original report.
                DifferentReport differentReport = new DifferentReport(report.Code + " some more code", "This is the value of the report"); ;
                // Add the new report to the children of RootXml
                XmlElement newNode = XmlNodeExtensions.SerializeToXmlElement(differentReport, (XmlElement)reportNode.ParentNode);
            }
    As you can see this is quite similar to what is possible with Linq-to-XML.
