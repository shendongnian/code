    // Read entire file;
    var lines = File.ReadAllLines("data2.txt");
    var eur = "EUR"; // String to insert.
    // Calc the position to insert at.
    var insertAt = "223016254".Length + 1; 
    var result = 
        lines
        .Select(x => 
            // Insert the 'eur' string.
            x.Insert(insertAt, eur)
            // Remove the spaces after insertion.
            .Remove(insertAt + eur.Length, eur.Length))
        .ToList();
