     public int CountMacNames(String macName, String path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            string[] lines = null;
            using (var sr = new System.IO.StreamReader(path))
                lines = sr.ReadToEnd().Split(new string[] {"\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            return lines.Where(p => p.Split(',').Contains(macName)).Count();
        }
