      string pattern = "([A-Za-z]{1,}[0-9.]*|[0-9.]{1,}[A-Za-z]*)";
      string input = "z5 100c x87.50.";
      MatchCollection matches = Regex.Matches(input, pattern);
      foreach (Match match in matches)
      {
         Console.WriteLine(match.Groups[1].Value);
         Console.WriteLine(match.Groups[2].Value);
         Console.WriteLine(match.Groups[3].Value);
      }
