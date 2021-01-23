    // get Listing.... existing one
    var existingListing = ... // GetExistingSomehow(); 
    // new space
    var space = new ListingSpace ();
    // must have assigned parent. MUST
    space.Listing = existingListing;
    // parnet colleciton is extended
    existingListing.ListingSpaces.Add(space);
    // save just parent, cascade will do the rest
    session.SaveOrUpdate(existingListing);
