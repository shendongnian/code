            string xml = @"<?xml version=""1.0""?>
            <name1>
              <irrelevant1>
                <irrelevant2>
                <!--
                  <irrelevant3 />
                -->
                </irrelevant2>
              </irrelevant1>
              <name2>
                <name3>
                <!--
                  <name4 field=""The"" />
                  <name4 field=""Owls"" />
                  <name4 field=""Are"" />
                  <name4 field=""Not"" />
                  <name4 field=""What"" />
                  <name4 field=""They"" />
                  <name4 field=""Seem"" />
                -->
                </name3>
              </name2>
            </name1>
            ";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            Debug.WriteLine(xmlDoc.ToXml());
            XmlNodeExtensions.UncommentXmlNodes(xmlDoc.DocumentElement.DescendantsAndSelf().OfType<XmlComment>().Where(c => c.ParentNode.Name == "name3"));
            Debug.WriteLine(xmlDoc.ToXml());
