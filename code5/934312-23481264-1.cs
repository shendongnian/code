        public class SiteDefinition
        {
            [XmlAttribute]
            public string Name { get; set; }
            [XmlAttribute]
            public string Version { get; set; }
            public List<MasterPage> MasterPages { get; set; }
            public List<File> Files { get; set; }
            public List<PageLayout> PageLayouts { get; set; }
            public List<Feature> Features { get; set; }
            public List<ContentType> ContentTypes { get; set; }
            public List<StyleSheet> StyleSheets { get; set; }
        }
        public class MasterPage
        {
            [XmlAttribute]
            public string Name { get; set; }
            [XmlAttribute]
            public string ServerFolder { get; set; }
            [XmlAttribute]
            public string UIVersion { get; set; }
            [XmlAttribute]
            public string Url { get; set; }
            [XmlAttribute]
            public string LocalFolder { get; set; }
        }
        public class StyleSheet
        {
        }
        public class ContentType
        {
        }
        public class Feature
        {
        }
        public class PageLayout
        {
        }
        public class File
        {
        }
        [Fact]
        public void Test()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SiteDefinition));
            using (FileStream stream = new FileStream("Data.xml", FileMode.Open))
            {
                var siteDefinition = (SiteDefinition)serializer.Deserialize(stream);
            }
        }
