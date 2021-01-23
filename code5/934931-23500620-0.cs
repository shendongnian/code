    public static void SaveRestaurantList(List<Restaurant> restaurantList) 
    { 
       using(FileStream fs = new FileStream("Restaurant.txt", FileMode.Create, FileAccess.Write))
       {
           BinaryFormatter bf = new BinaryFormatter(); 
           bf.Serialize(fs, restaurantList); 
       }
    }
