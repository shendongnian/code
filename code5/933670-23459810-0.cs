    public static List<Item> GetById(int id)
    {
        using (Scooterfrøen_Entities db = new Scooterfrøen_Entities())
        {
    		var listOfItemsById = from i in db.Item
    							  where i.Id == id 
                                  select i;
    						   
            return listOfItemsById.ToList();
        }
    }
