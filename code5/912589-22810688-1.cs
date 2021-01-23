    string[] lines = richTextBox1.Lines;
    List<string> linesToAdd = new List<string>();
    string filterString = "Banned".";
    foreach (string s in lines)
    {
        string temp = s;
        if (s.Contains(filterString))
           temp = s.Replace(filterString, string.Empty);
        linesToAdd.Add(temp);
     }
     richTextBox1.Lines = linesToAdd.ToArray(); 
