        public static List<string[]> Parse(string Path)
        {
            List<string[]> Parsed = new List<string[]>();
            using (StreamReader Reader = new StreamReader(Path))
            {
                string Line;
                char Seperator = ',';
                while ((Line = Reader.ReadLine()) != null)
                {
                    if (Line.Trim().StartsWith("//")) continue;
                    if (string.IsNullOrWhiteSpace(Line)) continue;
                    string[] Data = Line.Split(Seperator);
                    Parsed.Add(Data);
                }
            }
            return Parsed;
        } 
