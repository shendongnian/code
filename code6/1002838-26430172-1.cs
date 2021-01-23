    public static class WriteWord
    {
        public static MemoryStream BuildFile(string templatePath, XDocument xmlData)
        {
            MemoryStream rValue = null;
            byte[] fileBytes;
            fileBytes = File.ReadAllBytes(templatePath);
            rValue = BuildFile(fileBytes, xmlData);
            return rValue;
        }
        public static MemoryStream BuildFile(byte[] fileBytes, XDocument xmlData)
        {
            var rValue = new MemoryStream();
            var reader = xmlData.CreateReader();
            reader.MoveToContent();
            var xmlNamespace = reader.NamespaceURI; // "http://schemas.tempuri.org/product/v1/wordMetadata";
                        
            rValue.Write(fileBytes, 0, fileBytes.Length);
            var openSettings = new OpenSettings()
            {
                AutoSave = true,
                //MarkupCompatibilityProcessSettings = 
                //    new MarkupCompatibilityProcessSettings(
                //        MarkupCompatibilityProcessMode.ProcessAllParts, 
                //        FileFormatVersions.Office2013)
            };
            using (WordprocessingDocument doc = WordprocessingDocument.Open(rValue, true, openSettings))
            {
                MainDocumentPart main = doc.MainDocumentPart;
                var mainPart = doc.MainDocumentPart;
                var xmlParts = mainPart.CustomXmlParts;
                var ourPart = (CustomXmlPart)null;
                foreach (var xmlPart in xmlParts)
                {
                    var exists = false;
                    using (XmlTextReader xReader = new XmlTextReader(xmlPart.GetStream(FileMode.Open, FileAccess.Read)))
                    {
                        xReader.MoveToContent();
                        exists = xReader.NamespaceURI.Equals(xmlNamespace);
                    }
                    if (exists)
                    {
                        ourPart = xmlPart;
                        break;
                    }
                }
                using (var xmlMS = new MemoryStream())
                {
                    xmlData.Save(xmlMS);
                    xmlMS.Position = 0;
                    ourPart.FeedData(xmlMS);
                }
            }
            rValue.Position = 0;
            
            return rValue;
        }
    }
