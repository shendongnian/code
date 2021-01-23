        protected bool AreFilesTheSame(XmlDocument doc, string fileToCompareTo)
        {
            if (!File.Exists(fileToCompareTo))
                return (false);
            try
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(fileToCompareTo);
                return doc.OuterXml == doc2.OuterXml;
            }
            catch
            {
                return (false);
            }
        }
