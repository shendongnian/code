        private Dictionary<String, String> settingsConfig = new Dictionary<string,string>();
        private const string JSON_SEPARATOR = "\",\"";
        private const string JSON_SEPARATOR_WITH_NEWLINE = "\",\r\n\"";
        private void readConfig()
        {
            if (File.Exists(defaultFilePath))
            {
                JavaScriptSerializer reader = new JavaScriptSerializer();
                string fileContents = File.ReadAllText(defaultFilePath);
                fileContents = fileContents.Replace(JSON_SEPARATOR_WITH_NEWLINE, JSON_SEPARATOR);
                settingsConfig = reader.Deserialize<Dictionary<String, String>>(fileContents);
            }
        }
    
        public void saveConfig()
        {
            JavaScriptSerializer writer = new JavaScriptSerializer();
            string textToSave = writer.Serialize(settingsConfig);
            textToSave = textToSave.Replace(JSON_SEPARATOR, JSON_SEPARATOR_WITH_NEWLINE);
            File.WriteAllText(defaultFilePath, textToSave);
        }
