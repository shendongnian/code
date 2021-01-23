    Regex matcherRegex = 
      new Regex("(?<Summer>Summer)"
                + "|(?<Winter>Winter)"
                + "|(?<Outdoors>(^Exterior|ParkFacilities$))", 
                RegexOptions.Compiled | RegexOptions.ExplicitCapture);
    string Matcher(string input)
    {
      return matcherRegex.Match(input)
             .Groups
             .OfType<Group>()
             .Select((i, idx) => new { Item = i, Index = idx })
             .Skip(1)
             .Where(i => i.Item.Success)
             .Select(i => matcherRegex.GroupNameFromNumber(i.Index))
             .FirstOrDefault();
    }
