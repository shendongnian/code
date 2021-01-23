        IEnumerable<string> fileContents = Directory.EnumerateFiles("E:", "*.*", SearchOption.TopDirectoryOnly)
                .Select(x => new FileInfo(x))
                .Where(x => x.CreationTime > DateTime.Now.AddHours(-1) || x.LastWriteTime > DateTime.Now.AddHours(-1))
                .Where(x => x.Extension == ".xml" || x.Extension == ".txt")
                .Select(file => ParseFile(file));
        private string ParseFile(FileInfo file)
        {
            using (StreamReader sr = new StreamReader(file.FullName))
            {
                string line;
                string endResult;
                while ((line = sr.ReadLine()) != null)
                {
                    //Logic here to determine if this is the correct file and append accordingly
                    endResult += line + Environment.Newline;
                }
                return endResult;
            }
        }
