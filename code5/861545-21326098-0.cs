       List<BidResult> bidResults = new List<BidResult>();
       bidResults.Add(new BidResult{BidResultId = 1,ProductName = "Product 1"});
       bidResults.Add(new BidResult { BidResultId = 2, ProductName = "Product 2" });
       bidResults.Add(new BidResult { BidResultId = 3, ProductName = "Product 3" });
       List<Rating> ratings = bidResults.Select(tempResult => new Rating { BidResultId = tempResult.BidResultId }).ToList();
