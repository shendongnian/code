        public static class XObjectExtensions
        {
            public static T Deserialize<T>(this XContainer element)
            {
                return element.Deserialize<T>(new XmlSerializer(typeof(T)));
            }
            public static T Deserialize<T>(this XContainer element, XmlSerializer serializer)
            {
                using (var reader = element.CreateReader())
                {
                    object result = serializer.Deserialize(reader);
                    if (result is T)
                        return (T)result;
                }
                return default(T);
            }
            public static XElement Serialize<T>(this T obj, bool omitStandardNamespaces = true)
            {
                return obj.Serialize(new XmlSerializer(obj.GetType()), omitStandardNamespaces);
            }
            public static XElement Serialize<T>(this T obj, XmlSerializer serializer, bool omitStandardNamespaces = true)
            {
                var doc = new XDocument();
                using (var writer = doc.CreateWriter())
                {
                    XmlSerializerNamespaces ns = null;
                    if (omitStandardNamespaces)
                        (ns = new XmlSerializerNamespaces()).Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                    serializer.Serialize(writer, obj, ns);
                }
                return doc.Root;
            }
        }
    Then use them to pick out and deserialize known portions of your XML as follows:
            var doc = XDocument.Parse(xml);
            var reportElement = doc.Root.Element("Report");
            if (reportElement != null)
            {
                var report1 = doc.Root.Element("Report").Deserialize<Report>();
                // Do something with the report.
                // Create a different report 
                var differentReport = new DifferentReport { Code = report1.Code + " some more code", Value = "This is the value of the report" };
                var differentElement = differentReport.Serialize();
                reportElement.AddAfterSelf(differentElement);
                reportElement.Remove();
            }
