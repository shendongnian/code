    protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShadingAnalysisDataSetTableAdapters.tbl_CadEngineersTeamTableAdapter cd;
        cd = new ShadingAnalysisDataSetTableAdapters.tbl_CadEngineersTeamTableAdapter();
        DataTable dt = new DataTable();
        dt = cd.GetAvailableData(ddlCircle.SelectedValue); // Getting details of unassigned site
    
        int x, y; //z;
    
        DataTable dt3 = new DataTable();
        dt3 = cd.GetTeam();
        y = dt3.Rows.Count;
    
        x = dt.Rows.Count; // counting the unassinged sites
    
        DataTable dt2 = new DataTable();
        dt2 = cd.GetAssignTeam(x);           //Getting team based on count
    
        string[] arr = new string[dt2.Rows.Count];
        int i = 0;
        foreach (DataRow r in dt2.Rows)
        {
            arr[i] = r["Team"].ToString(); // assigning available team to array
            i++;
        }
    
        string[] strArr = new string[x+1]; // another array to copy arr values.
    
        i = 0; int j = 0;
        while (j <= x)
        {
            strArr[j]=  arr[i] ; // copying the arr[] values into strArr[] based on count.
            i++;
            j++;
    
            if (i == 3)
            {
                i = 0;
            }
        }
    
        GridView2.DataSource = strArr;
        GridView2.DataBind();
    }
