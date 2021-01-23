     string[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\fil.txt");
                        
            int ctr = 0;
            foreach (var item in lines)
            {
                string tmp = item;
                tmp = tmp.Replace("127.0.0.1", "");
                tmp = tmp.Replace("http://", "");
                tmp = tmp.Replace("www.", "");
                tmp = tmp.Trim();
                if (ctr < lines.Length)
                {
                    lines[ctr] = tmp;
                    ctr++;
                }
            }
            //to skip initial lines
            var result = lines.Skip(3).Distinct();
