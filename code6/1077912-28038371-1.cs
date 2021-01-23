        public static void Serialize<T>(T obj, string filename, bool omitStandardNamespaces = false)  // Change the default to true if you prefer.
        {
            using (var textWriter = new StreamWriter(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;        // For cosmetic purposes.
                settings.IndentChars = "    "; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    if (omitStandardNamespaces)
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                        serializer.Serialize(xmlWriter, obj, ns);
                    }
                    else
                    {
                        serializer.Serialize(xmlWriter, obj);
                    }
                }
            }
        }
