    var records = new Record[] {
        new Record 
        {
            Id = 1,
            Date = DateTime.Today,
            IsRepeatable = false,
            Name = "Unique",
            RepetitionType = 0
        },
        new Record 
        {
            Id = 2,
            Date = DateTime.Today,
            IsRepeatable = true,
            Name = "Daily",
            RepetitionType = 1
        },
        new Record
        {
            Id = 3,
            Date = DateTime.Today,
            IsRepeatable = true,
            Name = "Weekly",
            RepetitionType = 2,
            RepeatingEndDate = DateTime.Today.AddDays(7*2)
        }
    };
    
    var allRecords = records.ExpandRepetitions(DateTime.Today.AddDays(7), new DateTime(2015, 3, 25)).ToList();
