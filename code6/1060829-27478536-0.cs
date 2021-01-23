    DataTable tblTest = new DataTable(); //SELECT * FROM YourTable
    
    //Calculate sum of population
    Decimal overall = tblTest.AsEnumerable().Select(dr => dr.Field<Decimal>("Population")).DefaultIfEmpty().Sum();
    tblTest.Columns.Add("Percentage", typeof(Decimal));
    foreach(DataRow drow in tblTest.Rows)
    {
        Decimal percentage = YourPercentageCalculationResult; //Add you calculation
        drow.SetField<Decimal>("Percentage", percentage);
    }
    grid.DataSource = tblTest;
    
