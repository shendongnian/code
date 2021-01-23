     public int CountMacNames(String macName)
        {
            int resCnt = 0;
            string path = @"C:\222\macNameCounter.csv";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            string[] lines = null;
            using (var sr = new System.IO.StreamReader(path))
                lines = sr.ReadToEnd().Split(new string[] {"\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            List<string> added_lines = new List<string>();
            foreach (var line in lines)
            {
                bool isExists = line.Split(',').Any(x => x == macName);
                if (!isExists)
                {
                    // macName does not exists, add macName to CSV file and start counter by 1
                    var csv = new StringBuilder();
                    var newLine = string.Format("{0},{1}", macName, 1);
                    if (!added_lines.Contains(newLine))
                    {
                        csv.Append(newLine);
                        added_lines.Add(newLine);
                    }
                    using (var sw = new StreamWriter(path, true, Encoding.Unicode))
                      sw.WriteLine(csv.ToString());
                }
                else
                    resCnt++;
            }
            return resCnt;
        }
