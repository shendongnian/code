    Ad NextAd = db.Ads.First();
    
    public IQueryable<Ad> getAds(count)
    {
    	var firstTake = db.Ads
    		.OrderBy(x => x.Id)
    		.Where(x => x.Id >= NextAd.Id);
    	
    	var secondTake = db.Ads
    		.OrderBy(x => x.Id)
    		.Take(count - result.Count());
    	
    	var result = firstTake.Concat(secondTake);
        
        NextAd = result.LastOrDefault()
        return result;
    }
