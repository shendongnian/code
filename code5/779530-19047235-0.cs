    const string strRegex = @"([a-z_]\w*)_([a-z\d]+)";
    const RegexOptions myRegexOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant;
    Regex myRegex = new Regex(strRegex, myRegexOptions);
    string text = @"Some_Button1_Click";
    var matches = myRegex.Matches(text)
                  .Cast<Match>()
                  .Select(x => new {
                          AllText = x.Groups[0],  // Some_Button1_Click
                          Object = x.Groups[1],   // Some_Button1
                          Event = x.Groups[2]     // Click
                      })
                  .ToList();
