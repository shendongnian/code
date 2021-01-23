        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
         "attachment;filename=GridViewExport.csv");
        Response.Charset = "";
        Response.ContentType = "application/text";
        DataTable dt = new DataTable();
        string cn =      System.Configuration.ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cn);
        SqlCommand cmd = new SqlCommand("select a.Emp_Id,a.Emp_F_name,a.Emp_L_name,b.Dept_Name,a.Emp_dob,a.IsDeleted from Employee_tbl a Inner join Department_tbl b on a.Dept_Id=b.Dept_Id where a.IsDeleted='true'", con);
        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet dset = new DataSet();
        adp.SelectCommand = cmd;
        adp.Fill(dset);
        Gridview1.DataSource = dset.Tables[0];
        Gridview1.DataBind();
        Gridview1.AllowPaging = false;
        StringBuilder sb = new StringBuilder();
        int m;
        for (m = 0; m < Gridview1.Columns.Count; m++)
        {
            //add separator
            
            sb.Append(Gridview1.Columns[m].HeaderText+',' );
            
        }
        sb.Append("\r\n");
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                Label tt = Gridview1.Rows[i].FindControl("lblname") as Label;
                sb.Append(tt.Text + ',');
                tt = Gridview1.Rows[i].FindControl("Label4") as Label;
                sb.Append(tt.Text + ',');
                tt = Gridview1.Rows[i].FindControl("Label5") as Label;
                sb.Append(tt.Text );
                sb.Append("\r\n");
            }
        
        Response.Output.Write(sb.ToString());
        Response.Flush();
        Response.End();
    
