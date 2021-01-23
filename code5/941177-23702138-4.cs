    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;
    namespace Serializer
    {
        class XMLManager
        {
            private const string configFileName = "Departments.xml";
            public static List<Departments> Read()
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Departments>));
                using (FileStream file = File.OpenRead(Path.Combine(Global.AppRoot,      configFileName)))
                {
                    return reader.Deserialize(file) as List<Departments>;
                }
            }
            public static void Write(List<Departments> settings)
            {
                XmlSerializer writer = new XmlSerializer(typeof(List<Departments>));
                using (FileStream file = File.Create(Path.Combine(Global.AppRoot, configFileName)))
                {
                    writer.Serialize(file, settings);
                }
            }
        }
    }
