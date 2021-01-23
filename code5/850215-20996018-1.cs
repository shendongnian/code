        private Dictionary<string, string> ParseText(string text)
        {
           Dictionary<string, string> hostnameDictionary= new Dictionary<string, string>();
           foreach(var line in text.Trim().Split(Environment.NewLine)))
           {
               string[] textParts = line.Trim().Split(' ');
        
               if(textParts.Length == 2 && !hostnameDictionary.ContainsKey(textParts[0])
               {
                   hostnameDictionary.Add(textParts[0], textParts[1]);
               }
           }
           return hostnameDictionary;
        }
