    protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShadingAnalysisDataSetTableAdapters.tbl_CadEngineersTeamTableAdapter cd;
        cd = new ShadingAnalysisDataSetTableAdapters.tbl_CadEngineersTeamTableAdapter();
        DataTable dt = new DataTable();
        dt = cd.GetAvailableData(ddlCircle.SelectedValue); // Getting details of unassigned site
    
        int x, y;
    
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
    
            if (i == y)
            {
                i = 0;
            }
        }
         DataTable dt4 = new DataTable();
         dt4.Columns.Add("Team");
    
         foreach (string s in strArr)
           {
              dt4.Rows.Add(s); // Converting string array strArr[] to data table dt4
            }
     //Adding new data table for merging two table details
    
            DataTable dt7 = new DataTable();
    
            //create columns and copy data from dt:
    
            dt7 = dt.Copy();
    
            foreach (DataColumn column in dt4.Columns)
            dt7.Columns.Add(column.ColumnName, typeof(string));
        
    
            //copy data from dt4:
    
            foreach (DataRow row in dt4.Rows)
            {
                dt7.Rows[dt4.Rows.IndexOf(row)][5] = row[0];
            }    
    
            GridView3.DataSource = dt7;
            GridView3.DataBind();
    
        }
