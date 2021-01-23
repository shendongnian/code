        [Serializable()]
        [XmlRoot("Content")]
        public class Content
        {
            [XmlArray("Colours")]
            [XmlArrayItem("Colour")]
            public CustomColour[] Colours { get; set; }
            [XmlArray("Textures")]
            [XmlArrayItem("Texture")]
            public CustomTexture[] Textures { get; set; }
        }
        
        [Serializable()]
        [XmlRoot("Colour")]
        public class CustomColour
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlElement("R")]
            public int R { get; set; }
            [XmlElement("G")]
            public int G { get; set; }
            [XmlElement("B")]
            public int B { get; set; }
            [XmlElement("A")]
            public int A { get; set; }
        }
        [Serializable()]
        [XmlRoot("Texture")]
        public class CustomTexture
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlElement("Path")]
            public string Path { get; set; }
        }
        public static class ContentLoader
        {
            public static Content Load(TextReader textReader)
            {
                var serializer = new XmlSerializer(typeof(Content));
                var ret = serializer.Deserialize(textReader) as Content;
                return ret;
            }
            public static void Save(TextWriter textWriter, Content content)
            {
                var serializer = new XmlSerializer(typeof(Content));
                serializer.Serialize(textWriter, content);
            }
        }
        public static void XmlSerializing()
        {
            var xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
                        <Content xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                            <Colours>
                                <Colour name=""Strong Red"">
                                        <R>255</R>      
                                        <G>0</G>
                                        <B>0</B>
                                        <A>255</A> 
                                </Colour>
                            </Colours>
                            <Textures>
                                 <Texture name=""Character01"">
                                     <Path>Path/Folder</Path>
                                 </Texture>
                            </Textures>
                        </Content>";
            var reader = new StringReader(xml);
            var content = ContentLoader.Load(reader);
            Console.WriteLine("Deserialized version:");
            Console.WriteLine("  Colours");
            foreach (var colour in content.Colours)
            {
                Console.WriteLine("    R: {0}, G: {1}, B: {2}, A: {3}", colour.R, colour.G, colour.B, colour.A);
            }
            Console.WriteLine("  Textures");
            foreach (var texture in content.Textures)
            {
                Console.WriteLine("    Path: {0}", texture.Path);
            }
            var contentObj = new Content()
                                {
                                    Colours = new[] { new CustomColour() { Name = "StrongRed", R = 255, G = 0, B = 0, A = 255 } },
                                    Textures = new[] { new CustomTexture() { Name = "Character01", Path = "Path/Folder" } }
                                };
            Console.WriteLine(string.Empty);
            Console.WriteLine("Serialized version:");
            var writer = new StringWriter();
            ContentLoader.Save(writer, contentObj);
            Console.WriteLine(writer);
        }
