    var dliList = new List<DateLookupItem>();
    // Create a list of ten items. Every third one has the same date.
    for (int i = 1; i < 11; i++)
    {
        dliList.Add(new DateLookupItem
            {
                Id = i,
                Date = DateTime.Parse(string.Format("1-{0}-2014", 
                    (i % 3 == 0) ? "3" : i.ToString())),
                Description = i.ToString(),
            });
    }
    Console.WriteLine(
        string.Join(", ",
                    dliList.GroupBy(x => x.Date)
                            .Select(
                                date =>
                                    string.Format("({0}), {1}", 
                                        string.Join("/", date.Select(d => d.Description)),
                                        date.Key))));
