    // Read the small table into memory, and make a dictionary from it.
    // The last step will use this dictionary for joining.
    var byId = db1.MyStrings
        .Where(x => homeStrings.Contains(x.Content))
        .ToDictionary(s => s.Id);
    // Extract the keys. We will need them to filter the big table
    var ids = byId.Keys.ToList();
    // Bring in only the relevant records
    var myStrings = db2.MyStaticStringTranslations
        .Where(y => ids.Contains(y.id))
        .AsEnumerable() // Make sure the joining is done in memory
        .Select(y => new {
            Id = y.id
            // Use y.id to look up the content from the dictionary
        ,   Original = byId[y.id].Content
        ,   Translation = y.translation
        });
