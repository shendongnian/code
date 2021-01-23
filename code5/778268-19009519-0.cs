    DataTable dtFirst = new DataTable();
    dtFirst.Columns.Add("column1");
    dtFirst.Columns.Add("column2");
    dtFirst.Columns.Add("column3");
    
    FillDataTableFirst(); // before I create second DataTable - dtFirst is filled
    
    DataTable dtSecond = dtFirst.Clone();
