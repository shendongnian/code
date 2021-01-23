    DataTable dt = new DataTable();
    dt.Load(cmd.ExecuteReader());
                    
    DataColumn dcFullName = new DataColumn("FullName");
    dcFullName.Expression = string.Format("{0}+' '+{1}", "FirstName", "LastName");
    dt.Columns.Add(dcFullName);
    
    gridview_viewPSC.DataSource =  dt;
