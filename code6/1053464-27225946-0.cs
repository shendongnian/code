    public List<string> ConvertFile( )
            {
                string allLines = GetLinesFromFile();
                List<string> re = new List<string>();
                for (int i = 0; i < allLines.Length; i++)
                {
                    string[] split = allLines.Split(new Char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    allLines.Replace(";", ";" + split[0] + "|");
                    re.Add(allLines);
                }
                return re;
            }
