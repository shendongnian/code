        DataTable tab_lvl = new DataTable();
           tab_lvl.Columns.Add(new DataColumn("NO", typeof(string)));
           tab_lvl.Columns.Add(new DataColumn("Name", typeof(string)));
           tab_lvl.Columns.Add(new DataColumn("AGE", typeof(string)));
           tab_lvl.Columns.Add(newDataColumn("Allot_Asset_Code",typeof(string)));
    int count;
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
        {
            count++;
            DataRow dr = tab_lvl.NewRow();
            dr["NO"] = count;
            dr["NAME"] = ds.Tables[0].Rows[i]["COLname/number"];
            dr["AGE"] = ds.Tables[0].Rows[i]["COLname/number"];
        }
    
    //bind the datatable to the report
    objRpt.SetDataSource(tab_lvl);
