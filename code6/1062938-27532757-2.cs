    var users = AllUsers.Current;
    // physicalResults is IEnumerable<SearchResult>
    var physicalResults = rows.Select(r => new SearchResult(r))
        .Where(t => t.BookType == "Physical")
        .Where(e => e.CanViewPhysical(e.PhysicalBookResult, users) );
    // digitalResults is IEnumerable<SearchResult>
    var digitalResults = rows.Select(r => new SearchResult(r))
        .Where(t => t.BookType == "Digital")
        .Where(e => e.CanViewDigital(e.DigitalBookResult, users) );
