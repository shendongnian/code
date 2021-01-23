      public static void CreateFile(string xml)
        {
            var dateStamp = DateTime.Now.ToString("yyyy-MM-dd");
            var fileName = "file_" + dateStamp + ".xml";
            if (File.Exists(fileName))
            {
                Console.WriteLine("File already exists.");
                return;
            }
    
            using (FileStream fileStream = new FileStream(fileName, FileMode.CreateNew))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(xml);
                }
            }
        }
