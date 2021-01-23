    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;
    namespace Serializer
    {
        class XMLManager
        {
            private const string configFileName = "Departments.xml";
            public static Departments Read()
            {
                XmlSerializer reader = new XmlSerializer(typeof(Departments));
                using (FileStream file = File.OpenRead(Path.Combine(Global.AppRoot,      configFileName)))
                {
                    return reader.Deserialize(file) as Departments;
                }
            }
            public static void Write(Departments settings)
            {
                XmlSerializer writer = new XmlSerializer(typeof(Departments));
                using (FileStream file = File.Create(Path.Combine(Global.AppRoot, configFileName)))
                {
                    writer.Serialize(file, settings);
                }
            }
        }
    }
