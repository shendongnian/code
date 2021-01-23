        public static List<SiteDefinition> Read()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<SiteDefinition>));
            using (FileStream file = File.OpenRead(Path.Combine(Global.AppRoot, configFileName)))
            {
                return reader.Deserialize(file) as List<SiteDefinition>;
            }
        }
        public static void Write(List<SiteDefinition> settings)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<SiteDefinition>));
            using (FileStream file = File.Create(Path.Combine(Global.AppRoot, configFileName)))
            {
                writer.Serialize(file, settings);
            }
        }
