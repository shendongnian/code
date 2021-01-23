    var tableA = new DataTable();
    tableA.Columns.Add("Currency", typeof(string));
    tableA.Columns.Add("Rate1", typeof(decimal));
    tableA.Columns.Add("Rate2", typeof(decimal));
    tableA.Columns.Add("Rate3", typeof(decimal));
    tableA.Columns.Add("Rate4", typeof(decimal));
    tableA.Columns.Add("Rate5", typeof(decimal));
    tableA.Columns.Add("Rate6", typeof(decimal));
    
    tableA.Rows.Add("USD", 1m, 2m, 3m, 4m, 5.5m, 4.5m);
    tableA.Rows.Add("JPY", 1.11m, 4.1m, 3.3m, 4.6m, 5.5m, 3.3m);
    tableA.Rows.Add("GBP", 3.0m, 1m, 3m, 4m, 7.7m, 8.8m);
    tableA.Rows.Add("EUR", 3.0m, 1m, 3m, 4m, 7.7m, 8.8m);
    tableA.Rows.Add("MXN", 3.0m, 1m, 3m, 4m, 7.7m, 8.8m);
    
    
    var tableB = new DataTable();
    tableB.Columns.Add("Currency", typeof(string));
    tableB.Columns.Add("Rate1", typeof(decimal));
    tableB.Columns.Add("Rate2", typeof(decimal));
    tableB.Columns.Add("Rate3", typeof(decimal));
    tableB.Columns.Add("Rate4", typeof(decimal));
    
    tableB.Rows.Add("USD", 1m, 2m, 3m, 4m);
    tableB.Rows.Add("JPY", 1.11m, 9.9m, 3.3m, 4.6m);
    tableB.Rows.Add("GBP", 3m, 1m, 3m, 4m);
    
    var query = from r1 in tableA.AsEnumerable()
                from r2 in tableB.AsEnumerable()
                where
                    r1.Field<string>("Currency") == r2.Field<string>("Currency")
                        
                && r1.Field<decimal>("Rate1") == r2.Field<decimal>("Rate1")
                && r1.Field<decimal>("Rate2") == r2.Field<decimal>("Rate2")
                && r1.Field<decimal>("Rate3") == r2.Field<decimal>("Rate3")
                && r1.Field<decimal>("Rate4") == r2.Field<decimal>("Rate4")
        select r2;
    
    var result = tableB.AsEnumerable().Except(query).ToList();
