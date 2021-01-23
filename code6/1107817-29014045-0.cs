    foreach(var property in myClass.GetType().GetProperties())
    {
        SqlParameter newParam = new SqlParameter();
        newParam.Name = property.Name;
        ...
        // set other fields of the new parameter here and add it to the array 
        // the logic to determine the exact type of param can get hairy
     }
