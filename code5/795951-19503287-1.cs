    var groups = table.AsEnumerable()
        .GroupBy(r => new 
            { 
                Agency  = r.Field<string>("Agency"),
                Contact = r.Field<string>("Contact") 
            });
    foreach (var agencyContactGroup in groups)
       Console.WriteLine("Agency: {0} Contact: {1} Groups: {2} Count: {3}"
           , agencyContactGroup.Key.Agency
           , agencyContactGroup.Key.Contact
           , string.Join(",", agencyContactGroup.Select(r => r.Field<string>("Group")))
           , agencyContactGroup.Count());
