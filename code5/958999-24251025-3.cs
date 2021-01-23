    var regex = new Regex(@"(?<=Parameters Table).*?(?=(?:Parameters Table)|$)",
                          RegexOptions.Singleline);
    var vals = arrayToLookForNames
                   .SelectMany(x=>regex.Matches(x).Cast<Match>())
                   .Where(m=>m.Success)
                   .Select(m=>m.Value);
