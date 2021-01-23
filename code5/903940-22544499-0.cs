     DataTable table = new DataTable();
        table.Columns.Add("Time".ToString());
        table.Columns.Add("Type".ToString());
        table.Columns.Add("Desc".ToString());
        DataRow dr = table.NewRow();
        dr["Time"] = DateTime.Now;
        dr["Type"] = avt.ToString();
        dr["Desc"] = desc;
        table.Rows.Add(dr);
    
    datagridview1.DataSource = table;
