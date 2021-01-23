    var path = "input.txt";
    var culture = System.Globalization.CultureInfo.InvariantCulture;
    Dictionary<JournalInfo, List<JournalEntry>> map = 
        File.ReadLines(path) // lazy read one line at a time
            .Skip(1) // skip header
            .Select(line => line.Split(',')) // split into columns
            .Select((columns, lineNumber) => new JournalEntry() 
                {   // parse each line into a journal entry
                    LineNumber = lineNumber,
                    Info = new JournalInfo(
                        columns[1], 
                        DateTime.ParseExact(columns[2], "MM/dd/yyyy", culture)),
                    Amount = decimal.Parse(columns[3], culture)
                })
            .GroupBy(entry => entry.Info) // group by unique key
            .ToDictionary(grouping => grouping.Key, grouping => grouping.ToList()); 
