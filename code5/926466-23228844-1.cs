    var topListings = new List<Listing>();
    var regularListings = new List<Listing>();
    foreach (var x in listings)
    {
        if (x.TopStartDate >= DateTime.Now && x.TopExpireDate >= DateTime.Now)
            topListings.Add(x);
        else
            regularListings.Add(x);
    }
