    DataTable dt=new DataTable();
    dt.Columns.Add("Name");
    dt.Columns.Add("Price");
    dt.Columns.Add("Quantity");
    dt.Columns.Add("Total");
    dt.Rows.Add(new [] {serviceString ,Value,quantity ,Value*quantity });
