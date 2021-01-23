            DataTable table = new DataTable();
            table.Columns.Add("Devices");
            
            DataRow dr = table.NewRow();
            
            dr["Devices"] = DateTime.Now.ToString("M/d/yyyy HH:mm");
            table.Rows.Add(dr);
            myDetailsView.DataSource = table;
            myDetailsView.DataBind();
