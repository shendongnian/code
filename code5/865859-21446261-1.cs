    foreach(var listing in listings)
    {
        // does not create new list or array! just prepares in-memory query
        var items = listing.Reviews
                           .Concat<IEntity>(listing.OpenHours)
                           .Concat<IEntity>(listing.Photos)
                           .Concat<IEntity>(listing.Types);
    
        foreach(var item in items)
            item.ListingID = listing.ListingID;
    }
