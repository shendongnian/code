    var query = db.Restaurants
                .Include("Cuisine")
                
    if(type == 1)
    {
        query= query.Where(x => x.RestaurantName.Contains(keyword));
    } 
    else if(type == 2)
    {
        query = query.Where(x => x.Cuisine == keyword); 
    }
    else {
        query = query.Where(x => x.Rating == keyword);
    }
