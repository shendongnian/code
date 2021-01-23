    public static class CSVWriter
    {
        public static void WriteData<T>(string fileName, string path, IEnumerable<T> data)
        {
            string filePath = path + fileName + ".csv";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.AppendLine(data.ToString());
            }
    
            File.AppendAllText(filePath, sb.ToString());
        }
    }
