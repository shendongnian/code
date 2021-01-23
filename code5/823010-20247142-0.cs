    var customer = <get customer entity>;
    
    var filteredCheckProducts = context.Entry( customer )
        .Collection( c => c.CheckProducts )
        .Query()
        .Where( cp => cp.CheckType == checkType )
        .ToArray();
