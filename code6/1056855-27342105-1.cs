    var result = dictionary
                .GroupBy(x => x.Value) 
                .Where(g => g.Count() == 1);
    if(result.Any())
    {
        var value = result.First().First().Key;
    }
    
