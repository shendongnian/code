     string[] lines = richTextBox1.Lines;
     List<string> linesToAdd = new List<string>();
     foreach (string s in lines)
     {
         string temp = s;
         if (s.StartsWith("Hello Worlds") && s.EndsWith(";") && s.Contains("HERE"))
            temp = s.Replace("HERE", string.Empty);
         linesToAdd.Add(temp);
     }
     richTextBox1.Lines = linesToAdd.ToArray();
    
