            string FilePath = @"C:\test.txt";
            var text = new StringBuilder();
            foreach (string s in File.ReadAllLines(FilePath))
            {
                text.AppendLine(s.Replace("here", "here ADDED TEXT"));
            }
            using (var file = new StreamWriter(File.Create(FilePath)))
            {
                file.Write(text.ToString());
            }
