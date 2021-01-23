    var restaurants = await DbContext.Restaurants.GroupBy(g => g).ToListAsync();
    return restaurants.Select(s =>
      new RestaurantList()
      {
        Name = s.Key.Name,
        City = s.Key.City,
        Phone = s.Key.Phone,
        AvgRating = s.Average(a => Convert.ToDecimal(a.Rating.RatingValue)),
        NbrOfPeopleRating = s.Distinct().Count(c => Convert.ToBoolean(c.RatingId)),
        Id = s.Key.Id
      });
