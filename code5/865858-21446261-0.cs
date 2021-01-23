    foreach(var listing in listings)
    {
        var items = listing.Reviews
                           .Concat<IEntity>(listing.OpenHours)
                           .Concat<IEntity>(listing.Photos)
                           .Concat<IEntity>(listing.Types);
    
        foreach(var item in items)
            item.ListingID = listing.ListingID;
    }
