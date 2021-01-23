    // get the list of ratings from somewhere
    var ratings = new List<Rating>(); 
    
    // project each Rating object into an int by selecting the Id property
    var ids = ratings.Select(r => r.Id);
    // project each int value into a string using the method above
    var names = GetNamesFromIds(ids);
    
