     DataTable table = new DataTable();
        table.Columns.Add("Img",typeof(System.Drawing.Image));
        table.Columns.Add("Time");
        table.Columns.Add("Type");
        table.Columns.Add("Desc");
        DataRow dr = table.NewRow();
        if (status == true)
               dr["Img"]  = Properties.Resources.success;
            else
               dr["Img"]  = Properties.Resources.failure;
        dr["Time"] = DateTime.Now;
        dr["Type"] = avt.ToString();
        dr["Desc"] = desc;
        table.Rows.Add(dr);
    
    datagridview1.DataSource = table;
