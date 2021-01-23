        public static object Deserialize(string path, Type toType)
        {
            using (var sr = new FileStream(path, FileMode.Open))
            {
                SkillCollection p = null;
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(sr, new XmlDictionaryReaderQuotas());
                var serializer = new DataContractSerializer(toType);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (serializer.IsStartObject(reader))
                            {
                                Console.WriteLine(@"Found the element");
                                p = (SkillCollection)serializer.ReadObject(reader);
                                Console.WriteLine("{0} {1}    id:{2}",
                                    p.Slash.ToString(), p.Summon.ToString());
                            }
                            Console.WriteLine(reader.Name);
                            break;
                    }
                }
                return p;
            }
        }
