     var restaurants = new List<Restaurant>
        {
           new Restaurant("Pune", "Mc Donald's", "Pune Address #1"),
           new Restaurant("Pune", "Dominoes", "Pune Address #2"),
           new Restaurant("Nagpur", "Pizza Hut", "Nagpur Address #1")
        };
     var newDict = restaurants.GroupBy(r => r.City)
                              .ToDictionary(r => r.Key, r => r.ToList());
     foreach (var restaurant in newDict["Pune"])
     {
        Debug.WriteLine("City {0}, Address {1}, Brand {2}", restaurant.City, 
                        restaurant.Address, restaurant.Brand);
     }
