    private void SetInitialCourse()
        {
            //Create DataTable
            DataTable dt = new DataTable();
            DataRow dr = null;
    
            //Add initail values to DataTable
            dt.Columns.Add(new DataColumn("RowNumberCourse", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1Course", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2Course", typeof(string)));
            //dt.Columns.Add(new DataColumn("Column3", typeof(string)));
    
            dr = dt.NewRow();
            dr["RowNumberCourse"] = 1;
            dr["Column1Course"] = string.Empty;
            dr["Column2Course"] = string.Empty;
            //dr["Column3"] = string.Empty;
    
            dt.Rows.Add(dr);
            dr = dt.NewRow();
    
            //Store the DataTable in ViewState
            ViewState["CurrentTableCourse"] = dt;
            Course_Gridview.DataSource = dt;
            Course_Gridview.DataBind();
    
        }
