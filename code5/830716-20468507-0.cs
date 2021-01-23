    string[] partNumbers = { "US", "1", "UK", "Australia", "Germany", "70", "9" };
    partNumbers.OrderBy(x =>
        { 
            int parseResult; 
            return int.TryParse(x, out parseResult) 
                ? parseResult 
                : null as int?; 
        }) 
        .ThenBy(x => x);
