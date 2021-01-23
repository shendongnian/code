    static void Main(string[] args)
        {
            Test t1 = new Test(1, "t1", new[] { "a", "b" });
            Test t2 = new Test(2, "t2", new[] { "c", "d", "e" });
            XmlSerializer serializer = new XmlSerializer(typeof(Test));
            //using (StreamWriter writer = new StreamWriter(@"f:\test\test.xml"))
            {
                XmlWriter xmlWriter = XmlWriter.Create(@"test.xml",
                                                       new XmlWriterSettings()
                                                       {
                                                           ConformanceLevel = ConformanceLevel.Fragment,
                                                           OmitXmlDeclaration = false,
                                                           Indent = true,
                                                           NamespaceHandling = NamespaceHandling.OmitDuplicates
                                                       });
                xmlWriter.WriteWhitespace("");
                serializer.Serialize(xmlWriter, t1);
                serializer.Serialize(xmlWriter, t2);
                xmlWriter.Close();
            }
        }
