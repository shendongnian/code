    BidResult bidResult = new BidResult();
    List<BidResult> bidResultList = new List<BidResult>();
    // Lets Adding Some Data to bidResultList
    bidResult.BidResultId = 1;
    bidResult.ProductName = "A";
    bidResultList.Add(bidResult);
    bidResult.BidResultId = 2;
    bidResult.ProductName = "B";
    bidResultList.Add(bidResult);
    bidResult.BidResultId = 3;
    bidResult.ProductName = "C";
    bidResultList.Add(bidResult);
    List<Rating> ratingList = bidResultList.Select(bid => new Rating { BidResultId = bid.BidResultId }).ToList();
