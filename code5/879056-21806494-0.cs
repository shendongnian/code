    public static class FileHelper
    {
        public static string[] ReadAllLines(string path)
        {
            if (File.Exists(path))
            {
                List<string> lines = new List<string>();
                using (var reader = new StreamReader(path))
                {
                    while(!reader.EndOfStream)
                        lines.Add(reader.ReadLine());
                }
                return lines.ToArray();
            }
            return null;
        }
    }
