    public static class Connection
        {
            public static ArrayList GetCoffeeByType(string coffeetype)
            {
                ArrayList list = new ArrayList();
                try
                {
                    mydbEntities db = new mydbEntities();
                    var query = from p in db.tableabc select p;
                    list = query.ToList();
    
                }
                catch (Exception ex)
                {
                   Alert.Show(ex.Message);
    
                }
                return list;
            }
    }
