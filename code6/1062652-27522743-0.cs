        public void GetScannerConfigFile()
        {
            string File = ConfigurationManager.AppSettings["RFIDScannerConfiguration"];
            XmlDocument doc = new XmlDocument();
            doc.Load(File);
            var yourFile = doc.DocumentElement;
            if (yourFile == null) return;
            // Here you'll get the attribute key: key = Active_01 - which can be simply parsed for getting only the "1"
            string key = yourFile.ChildNodes[0].Attributes["key"].Value;
            // Here you'll get the number "1" from the value attribute.
            string value = yourFile.ChildNodes[0].Attributes["value"].Value;
        }
