       public static XmlDocument LoadXmlDocument(string assertionFile) {
            using (var fs = File.OpenRead(assertionFile))
            {
                var document = new XmlDocument { PreserveWhitespace = true };
                document.Load(fs);
                fs.Close();
                return document;
            }
        }
