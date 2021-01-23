    var newLines = File.ReadAllLines(fileName);
      for (int i = 0;i<newLines.Length;i++)
        {
           Regex regex = new Regex(@"[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}");
              foreach (Match match in regex.Matches(newLines[i]))
               {
                 string modifiedDate = DateTime.Parse(match.Value).ToString("yyyy-MM-dd");
                 newLines[i] = newLines[i].Replace(match.Value, modifiedDate);
                }
         }
     File.WriteAllLines(fileName, newLines);
