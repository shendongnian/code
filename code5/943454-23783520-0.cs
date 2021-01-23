    public static partial class EntitiesExporter
    {
        public static void ExportEntityList<T>(string fileLocation, IEnumerable<T> entityList, string seperator = " , ")
        {
            string content = CreateFileContent<T>(entityList, seperator);
            SaveContentToFile(fileLocation, content);
        }
        private static string CreateFileContent<T>(IEnumerable<T> entityList, string seperator)
        {
            StringBuilder result = new StringBuilder();
            List<PropertyInfo> properties = new List<PropertyInfo>();
            foreach (PropertyInfo item in typeof(T).GetProperties())
            {
                if (item.CanWrite)
                {
                    properties.Add(item);
                }
            }
            foreach (T row in entityList)
            {
                var values = properties.Select(p => p.GetValue(row, null));
                var line = string.Join(seperator, values);
                result.AppendLine(line);   
            }
            return result.ToString();
        }
        private static void SaveContentToFile(string fileLocation, string content)
        {
            using (StreamWriter writer = File.CreateText(fileLocation))
            {
                writer.Write(content);
                writer.Close();
            }
        }
    }
