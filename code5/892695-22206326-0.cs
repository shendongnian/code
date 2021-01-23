    var getrestaurantaverage = db.Reviews
        .Where(r => getrestaurantsid.Contains(r.RestaurantId))
        .GroupBy(r => r.RestaurantId)
        .Select(g => new { ID = g.Key, Average = g.Average(r => r.score) });
    foreach (var x in getrestaurantaverage) {
        Console.WriteLine("Restaurant = {0}, average = {1}", x.ID, x.Average);
    }
