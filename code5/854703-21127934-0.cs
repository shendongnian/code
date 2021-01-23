    int counter = 1;
    string pattern = @"access-group\s+\w+\s+out\s+interface\s+\w+";    
    var totalMatches = 0;
    var output = new StringBuilder();
    foreach(var line in Lines(ofd.FileName))
    {
         var matches = Regex.Matches(line, pattern).Count;
         if (matches > 0)
         {
            totalMatches += matches;
            output.AppendLine(string.Format("Line: {0} {1}", counter, line));
         }
         counter++;
    }
    if(toatlMatches > 0)
    {
       richTextBox2.SelectionFont = new Font("Courier New", 8);
       richTextBox2.AppendText(">>> ACls installed by using access-group using the keyword OUT are NOT supported: " + "\u2028");
       richTextBox2.AppendText(">>> Total of incidences found: " + totalMatches.ToString() + "\u2028");
       richTextBox2.AppendText(output.ToString());
    }
