        [Fact]
        public void Test()
        {
            var builds = new builds
                {
                    build = new[]
                        {
                            new build
                                {
                                    buildTypeId = "1",
                                    number = 100,
                                    running = true
                                },
                            new build
                                {
                                    buildTypeId = "2",
                                    number = 200,
                                    running = true
                                }
                        }
                };
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            var writer = new StringWriter();
            new XmlSerializer(typeof(builds)).Serialize(writer, builds, namespaces);
            string result = writer.ToString();
            Console.Write(result);
        }
        [XmlRoot("builds")]
        public class builds
        {
            [XmlElement("build")]
            public build[] build;
            [XmlAttribute("count")]
            public int count { get; set; }
        }
        public class build
        {
            [XmlAttribute("buildTypeId")]
            public string buildTypeId;
            [XmlAttribute("href")]
            public string href;
            [XmlAttribute("id")]
            public int id;
            [XmlAttribute("number")]
            public int number;
            [XmlAttribute("percentageComplete")]
            public int percentageComplete;
            [XmlAttribute("running")]
            public bool running;
            [XmlAttribute("startDate")]
            public string startDate;
            [XmlAttribute("status")]
            public string status;
            [XmlAttribute("webUrl")]
            public string webUrl;
        }
