    var auctionData = db.Auctions.OrderBy(item => item.EndTime);
    var keyword = criteria.SearchKeyword;
    if (!string.IsNullOrEmpty(keyword))
    {
        auctionData = auctionData.Where((q => q.Description.Contains(keyword));
    }
