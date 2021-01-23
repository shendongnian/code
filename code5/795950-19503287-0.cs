    var groups = table.AsEnumerable()
        .GroupBy(r => new 
            { 
                Agency  = r.Field<string>("Agency"),
                Contact = r.Field<string>("Contact") 
            });
    foreach(var agencyContactGroup in groups)
        Console.WriteLine("Agency: {0} Contact: {1} Count: {2}"
            , agencyContactGroup.Key.Agency
            , agencyContactGroup.Key.Contact
            , agencyContactGroup.Count());
