    public bool IsPattern(string formatPattern, string formattedString, IList<string> arguments)
    {
      //Argument checks
      Regex regex = new Regex("{\\d+}");
      string regexPattern = regex.Replace(formatPattern, "(.*)");
      regex = new Regex(regexPattern);
      string.Format()
      if (regex.IsMatch(formattedString))
      {
        MatchCollection matches = regex.Matches(formattedString);
        Match match = matches[0];
        for (int i = 1; i < match.Groups.Count; i++)
        {
          arguments.Add(match.Groups[i].Value);
        }
        return true;
      }
      return false;
    }
