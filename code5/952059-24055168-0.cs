       Map = listings => listings
            .Select(listing => new
        {
            category = listing.Category,
            make = listing.Make,
            size = listing.Size // Size may sometimes be NULL                
        }).Where(e => e.Size != null); 
