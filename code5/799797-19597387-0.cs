    string data = "*Alpha/Beta/Gamma*Zebra/Delta/Tango";
    
    string pattern = @"\*((?<SlashValues>[^/*]+)/?)+";
    
    var viewItems =
        Regex.Matches(data, pattern, RegexOptions.IgnorePatternWhitespace)
             .OfType<Match>()
             .Select (mt => new {
                                LVI = new ListViewItem(),
    
                                SubItems = mt.Groups["SlashValues"].Captures
                                                                   .OfType<Capture>()
                                                                   .Select (cp => cp.Value),
                                }
                    )
            .ToList()
            .ForEach(item => {
                                item.LVI.AddRange(item.SubItems);
                                listView1.Items.Add(item);
                             });
