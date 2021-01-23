    // Below I am using C# properties, which I guess are correct
    // based on the mapping. Naming convention is more Java (camel)
    // but this should work with above mapping 
    // (also - class name Contact, not File)
    Files file = null; // this is an alias used below
    // here the attributes collection represents search filter
    // ... settings for which is user looking for
    var attributes = new List<Attrs>
    {
        new Attrs{ name = "mode", value = "read-only" },
        new Attrs{ name = "view", value = "visible" }
    };
    // Let's start with definition of the outer/top query
    // which will return all files, which do meet all filter requirements
    var query = session.QueryOver<Files>(() => file);
