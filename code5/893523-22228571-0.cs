            static void Main(string[] args)
            {
                var fileListEntries = from line in lines
                                      where !(line.StartsWith("#"))
                                      select ( ModifyString(line));
    
            }
    
            private static string[] ModifyString(string line)
            {
                string[] elements = line.Split(';');
                elements[0] = "modifiedString";
                return elements;
            }
