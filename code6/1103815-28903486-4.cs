    public static class TestXmlStreamingPatcher
    {
        public static void Test()
        {
            string mainXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <INI>
       <TABLE name=""People"">
          <ROW>
             <ID>1</ID>
             <Name><![CDATA[Bob]]></Name>
          </ROW>
       </TABLE>
       <TABLE name=""Animals"">
          <ROW>
             <ID>1</ID>
             <Name><![CDATA[Golden]]></Name>
          </ROW>
       </TABLE>
    </INI>
    ";
            string patchXml = @"<TABLE name=""People"">
          <ROW>
             <ID>1</ID>
             <Name><![CDATA[Mary]]></Name>
          </ROW>
          <ROW>
             <ID>2</ID>
             <Name><![CDATA[Bob]]></Name>
          </ROW>
          <ROW>
             <ID>3</ID>
             <Name><![CDATA[Dan]]></Name>
          </ROW>
       </TABLE>
    ";
            var patchedXml1 = TestPatch(mainXml, patchXml);
            Debug.WriteLine(patchedXml1);
        }
        private static string TestPatch(string mainXml, string patchXml)
        {
            using (var mainReader = new StringReader(mainXml))
            using (var mainXmlReader = XmlReader.Create(mainReader))
            using (var patchReader = new StringReader(patchXml))
            using (var patchXmlReader = XmlReader.Create(patchReader))
            using (var mainWriter = new StringWriter())
            {
                using (var mainXmlWriter = XmlWriter.Create(mainWriter))
                {
                    var patcher = new XmlStreamingPatcher(mainXmlReader, mainXmlWriter, patchXmlReader, ShouldPatchFrom, ShouldPatchFromTo);
                    patcher.Process();
                }
                return mainWriter.ToString();
            }
        }
        static bool ShouldPatchFrom(XmlReader reader)
        {
            return reader.GetElementName() == "TABLE";
        }
        static bool ShouldPatchFromTo(XmlReader patchReader, XmlReader toReader)
        {
            if (patchReader.GetElementName() != toReader.GetElementName())
                return false;
            string name = patchReader.GetAttribute("name");
            if (string.IsNullOrEmpty(name))
                return false;
            return name == toReader.GetAttribute("name");
        }
    }
