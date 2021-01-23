    // Where(x => true) might not be necessary, you can try skipping it.
    var query = repository.ItemOwners.Include("OwnerDetails").Where(x => true);
    if (searchCriteria.OwnerID != null)
        query = query.Where(s => s.OwnerID == searchCriteria.OwnerID);
    if (searchCriteria.ItemID != null)
        query = query.Where(s => s.ItemID == searchCriteria.ItemID);
    if (searchCriteria.OwnerID != null)
        query = query.Where(s => s..OwnerDetails.LocationId == searchCriteria.LocationID);
    var results = query.Select(s => new { s.OwnerDetails.OwnerName, s.OwnerDetails.MobNumber }).ToList();
