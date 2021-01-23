    var str = "group = '2843360' and (team in ('TEAM1', 'TEAM2','TEAM3'))";
    
    // grabs the group ID
    var group = Regex.Match(str, @"group = '(?<ID>\d+)'", RegexOptions.IgnoreCase)
        .Groups["ID"].Value;
    
    // grabs everything inside teams parentheses 
    var teams = Regex.Match(str, @"team in \((?<Teams>(\s*'[^']+'\s*,?)+)\)", RegexOptions.IgnoreCase)
        .Groups["Teams"].Value;
    
    // trim and remove single quotes
    var teamsArray = teams.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(s =>
            {
                var trimmed = s.Trim();
                return trimmed.Substring(1, trimmed.Length - 2);
            }).ToArray();
