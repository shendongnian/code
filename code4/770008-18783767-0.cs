    var query = ds.Tables["tblOriginal"].AsEnumerable();
    
    int year;
    if (Int32.TryParse(cmbFilterYear.Text, out year)) // condition for adding filter
        query = query.Where(r => r.Field<DateTime>("Datum").Year == year);
    // repear for other conditions
    ds.Tables["tblFilteredData"].Merge(query.CopyToDataTable()); // execute query
