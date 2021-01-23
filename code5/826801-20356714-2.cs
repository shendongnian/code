        private static string GetTestClassName(IAttachmentCollection attachmentCol)
        {
            if (attachmentCol == null || attachmentCol.Count == 0)
            {
                return string.Empty;
            }
            var attachment = attachmentCol.First(att => att.AttachmentType == "TmiTestResultDetail");
            var content = new byte[attachment.Length];
            attachment.DownloadToArray(content, 0);
            var strContent = Encoding.UTF8.GetString(content);
            var reader = XmlReader.Create(new StringReader(RemoveTroublesomeCharacters(strContent)));
            var root = XElement.Load(reader);
            var nameTable = reader.NameTable;
            if (nameTable != null)
            {
                var namespaceManager = new XmlNamespaceManager(nameTable);
                namespaceManager.AddNamespace("ns", "http://microsoft.com/schemas/VisualStudio/TeamTest/2010");
                var classNameAtt = root.XPathSelectElement("./ns:TestDefinitions/ns:UnitTest[1]/ns:TestMethod[1]", namespaceManager).Attribute("className");
                if (classNameAtt != null) return classNameAtt.Value.Split(',')[1].Trim();
            }
            return string.Empty;
        }
        internal static string RemoveTroublesomeCharacters(string inString)
        {
            if (inString == null) return null;
            var newString = new StringBuilder();
            foreach (var ch in inString)
            {
                // remove any characters outside the valid UTF-8 range as well as all control characters
                // except tabs and new lines
                if ((ch < 0x00FD && ch > 0x001F) || ch == '\t' || ch == '\n' || ch == '\r')
                {
                    newString.Append(ch);
                }
            }
            return newString.ToString();
        }
