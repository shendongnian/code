    List<BidResult> bidresults = new List<BidResult>() {
        new BidResult() { BidResultId = 1, ProductName = "hello"},
        new BidResult() { BidResultId = 2, ProductName = "world"}
    };
    
    ///////
    Mapper.CreateMap<BidResult, Rating>();
    
    var ratings = Mapper.Map<List<Rating>>(bidresults);
    ///////
    
    foreach (var rating in ratings)
        Console.WriteLine("{0},{1}", rating.BidResultId, rating.RatingId);
