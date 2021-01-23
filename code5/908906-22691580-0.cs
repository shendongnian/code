    public DataTable[] MultipleMethod(args)
    {
        List<DataTable> list = new List<DataTable>();
    
        // Load first DataTable
        DataTable dt = ...
        list.Add(dt);  // Add the DataTable to the list of tables
    
        // Load second DataTable
        dt = ...
        list.Add(dt);  // Add the DataTable to the list of tables
    
        // Load another DataTable
        dt = ...
        list.Add(dt);  // Add the DataTable to the list of tables
        
        return list.ToArray();  // Return an array of tables (can return the list if that is the return type)
    }
