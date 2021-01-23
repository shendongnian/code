    foreach (Restaurant restaurant in allRestaurant)
    {
         GeoCoordinate help;
         GeocodeQuery query = new GeocodeQuery()
         {
             GeoCoordinate = new GeoCoordinate(),
             SearchTerm = restaurant.address
         };
         TaskCompletionSource<Restaurant> task = new TaskCompletionSource<Restaurant>();
         query.QueryCompleted += (s, ev) =>
         {
             foreach (var item in ev.Result)
             {
                 help = item.GeoCoordinate;
                 task.TrySetResult(restaurant);
             }
             task.TrySetResult(null);
         };
         query.QueryAsync();
         var rest = (await task.Task);
         if (rest != null) 
             restaurants.Add(rest);
     }
