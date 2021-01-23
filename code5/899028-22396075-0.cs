     public ActionResult Search(string q)
     {
       Helpers Helpers = new Helpers();
       var restaurants = Helpers.getRestaurant(q);
       if(restaurants.Count()>0)
       {
         return View("_RestaurantSearchResults", restaurants);
       }
      else
      {
        ViewBag.Message="No result found";
        return View("_RestaurantSearchResults");
      }
     }   
