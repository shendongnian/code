    string[] lines = richTextBox1.Lines;
    List<string> linesToAdd = new List<string>();
    foreach(string s in lines)
    {
      if(s.StartsWith("Hello Worlds") && s.EndsWith(";") && s.Contains("HERE"))
       s = s.Remove("HERE");
      linesToAdd.Add(s);
    }
    richTextBox1.Lines = linesToAdd.ToArray();
    
