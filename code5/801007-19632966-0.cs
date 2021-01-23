    foreach (var g in data.GroupBy(p=>Id)) {
        Console.WriteLine(                  // Change this to the desired destination
            "{0} => {1}"
        ,   g.Key                                     // Produces GUID
        ,   string.Join(",", g => g.Select(p=>p.Val)) // Makes a comma-separated list
        );
    }
