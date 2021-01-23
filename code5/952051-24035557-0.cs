      static  IEnumerable<string> LineSplitter(string line)
            {
                int fieldStart = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ',')
                    {
                        yield return line.Substring(fieldStart, i - fieldStart);
                        fieldStart = i + 1;
                    }
                    if (line[i] == '"')
                        for (i++; line[i] != '"'; i++) { }
                }
               
            }
