    public DataTypeHere ExampleFunction()
    {
        var myTable = new DataTable();  // <---- You can see the type here
        var myAdapter = new SqlDataAdapter();  
        myAdapter.SelectCommand = myCommand;  
        myAdapter.Fill(myTable);
    
        return myTable;
    }
