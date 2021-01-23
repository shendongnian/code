    DataTable table; //Your Datatable
    List<DataTable> allCountryTables = new List<DataTable>();
            
    //Get distinct countries from table
    DataView view = new DataView(table);
    DataTable distinctValues = view.ToTable(true, "Country");
    
    //Create new DataTable for each of the distinct countries identified and add to allCountryTables list    
    foreach (DataRow row in distinctValues.Rows)
    {
        //Remove filters on view
        view.RowFilter = String.Empty;
        //get distinct country name
        String country = row["Country"].ToString());
        //filter view for that country
        view.RowFilter = "Country = " + country;
        //export filtered view to new datatable
        DataTable countryTable = view.ToTable();
        //add new datatable to allCountryTables 
        allCountryTables.Add(countryTable);
    }
