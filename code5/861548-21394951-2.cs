    List<Rating> ratings = null;
    List<BidResult> tempList = new List<BidResult> {
        new BidResult { BidResultId = 1, ProductName = "First Product" },
        new BidResult { BidResultId = 2, ProductName = "Second Product" }
    };
    List<List<BidResult>> bidResults = new List<List<BidResult>> { tempList };
                        
    var i = 1; // just a variable to assign a rating id for the console output
    ratings = bidResults
        .SelectMany(innerResults => innerResults) // required to flatten out the list of lists
        .Select(bidResult => new Rating { // bidResult is now a BidResult object
            RatingId = i++, 
            BidResultId = bidResult.BidResultId 
        }).ToList();
    foreach (var result in ratings)
    {
        Console.WriteLine("RatingID: {0} - BidResultID: {1}", result.RatingId, result.BidResultId);
    }
    Console.Read(); // don't exit until user hits a key
