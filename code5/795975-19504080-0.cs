    public DataTypeHere ExampleFunction()
    {
        myTable = new DataTable();  // <---- You can see the type here
        myAdapter = new SqlDataAdapter();  
        myAdapter.SelectCommand = myCommand;  
        myAdapter.Fill(myTable);
    
        return myTable;
    } 
