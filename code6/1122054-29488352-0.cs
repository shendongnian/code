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
            foreach (var line in lines)
            {
                bool isExists = line.Split(',').Any(x => x == macName);
                if (!isExists)
                {
                    // macName does not exists, add macName to CSV file and start counter by 1
                    var csv = new StringBuilder();
                    var newLine = string.Format("{0},{1}", macName, 1);
                    csv.AppendLine(newLine);
                    File.WriteAllText(path, csv.ToString());
                }
                else
                    resCnt++;
            }
            return resCnt;
        }
