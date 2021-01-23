            List<string> data = new List(string);
            using (var fs = File.Open(importFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var bs = new BufferedStream(fs))
                {
                    using (var sr = new StreamReader(bs))
                    {
                        String readLine;
                        while ((readLine = sr.ReadLine()) != null)
                        {
                            if (String.IsNullOrEmpty(readLine) || readLine == "---EOF---")
                            {
                                break;
                            }
                            data.Add(readLine);
                        }
                    }
                }
            }
            var rights =
                data.Select(row => row.Split(new[] { ";" }, StringSplitOptions.None))
                    .SelectMany(GetData).ToList();
        
