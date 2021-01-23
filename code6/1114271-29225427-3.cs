    // instead of this
    // var left = Projections.Property<DateTime>(effDate);
    
    // we would use this
    // DateTime effDate is passed in
    var effDate = DateTime.Today.Date; // C#'s today
    var left = Projections.Constant(effDate);
    
