    foreach var restaurantID in getrestaurantsid)
    {
        var getrestaurantaverage = db.Reviews.Where(r => r.RestaurantId = getrestaurantsid).Average(r => r.score);
        
        var choices = (from r in db.Reviews
                       where getrestaurantaverage >= averagescore
                       select r.RestaurantId).ToList();
        foreach (var item in choices)
        {
            var suggestion = new Suggestion()
            {
                reviewid = review.id,
                Userid = review.UserId,
                restaurantid = item
            };
            db.Suggestions.Add(suggestion);
            db.SaveChanges();
        }
    
    }
