    var regionFromDb = dbContext.Set<Region>().Find(regionVm.RegionId);
    var countriesToRemove = regionFromDb.Countries.Where(x => !regionVm.Countries.Contains(x.CountryId)).ToList();
    foreach (var country in countriesToRemove)
    {
        regionFromDb.Countries.Remove(country);
    }
    
    var countryIdsToAdd = regionVm.Countries.Where(x => !regionFromDb.Countries.Any(c => c.CountryId == x)).ToList();
    
    // Load countries where CountryId in countryIdsToAdd collection
    var countriesToAdd = dbContext.Set<Country>().Where(x => countryIdsToAdd.Contains(x.CountryId));
    foreach (var country in countriesToAdd)
    {
        regionFromDb.Countries.Add(country);
    }
    
    dbContext.SaveChanges();
