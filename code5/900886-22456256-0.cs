    var strippedRealList = reallist.Select(s => Regex.Replace(s, "[^0-9a-zA-Z]+", ""))
                                   .Where(s => s.Length >= 4)
                                   .ToArray();
    foreach (string realrecord in reallist)
    {
       strippedRealList.Where(s => realrecord.Contains(s))
                       .ToList()
                       .ForEach(s =>
                                matchTextBox.AppendText("Match: "
                                                      + s
                                                      + " & "
                                                      + realrecord
                                                      + Environment.NewLine));
                        
    }
