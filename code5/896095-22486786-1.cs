     public List<User> GetUsersByLocation(string schema, int locationId)
     {
        using(var ctx = new MyDbContext(schema))
        {
           // query the database ...
        }
     }
