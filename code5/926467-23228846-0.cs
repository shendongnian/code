    var topListings = new List<Listing>();
    var regularListings = new List<Listing>();
    
    listing.ForEach(item=>{
                          if (x.TopStartDate < DateTime.Now 
                                ||       // I've inverted the condition, since it is faster-one or two conditions will be checked, instead of always two
                              x.TopExpireDate < DateTime.Now)
                            regularListings.Add(x);
                          else
                            topListings.Add(x);
                    });
