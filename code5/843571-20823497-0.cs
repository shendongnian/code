    DataTable tbl = new DataTable();
    Datacolumn dc = new Datacolumn("ID");
    Datacolumn dc1 = new Datacolumn("col1");
    
    Datarow dr = tbl.NewRow();
    
    dr[dc] = "123";
    dr[dc1] = "SomeData";
    
    tbl.Rows.Add(dr);
    
    DataGridView.DataSource = tbl;
