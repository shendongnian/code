    using (SqlDataReader dr = cmd.ExecuteReader())
    {
       List<MyClass> results = new List<MyClass>();
       while(dr.Read())
       {
           MyClass newItem = new MyClass();
  
           newItem.Id = dr.GetInt32(0);  
           newItem.TypeId = dr.GetInt32(1);  
           newItem.AllowedSMS = dr.GetBoolean(2);  
           newItem.TimeSpan = dr.GetString(3);
           newItem.Price = dr.GetDecimal(4);
           newItem.TypeName = dr.GetString(5);
  
           results.Add(newItem);
       }
    }
    // return the results here, or bind them to a gridview or something....
 
