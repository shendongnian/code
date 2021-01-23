    string data = "*Alpha/Beta/Gamma*Zebra/Delta/Tango";
    
    string pattern = @"\*((?<SlashValues>[^/*]+)/?)+";
    
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
                            item.LVI.Text = item.SubItems.FirstOrDefault(),
                            LVI.AddRange(item.SubItems.Skip(1));
                            listView1.Items.Add(item);
                         });
