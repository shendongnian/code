        List<SelectUsers> items = new List<SelectUsers>();
        
        DataTable DetailsTbl = new DataTable();
        int gimId = 0;
        if (DetailsTbl.Rows[0]["RwId"] != "")
        {
            gimId = Convert.ToInt32(DetailsTbl.Rows[0]["RwId"]);
        }
        DataTable dtAssignTo = SLAFacadeBLL.GetGIMIncidentUsers(gimId);
        if (dtAssignTo != null && dtAssignTo.Rows.Count > 0)
        {
            foreach (DataRow row in dtAssignTo.Rows)
            {
                SelectUsers selectuser = new SelectUsers();
                selectuser.Value = row["Value"].ToString(); // row["column name in the datatable"].ToString();
                selectuser.Text = row["Text "].ToString();  // row["column name in the datatable"].ToString();
                items.Add(selectuser);
            }
        }
    }
