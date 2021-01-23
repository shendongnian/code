    Protected void btn_Click(object sender, EventArgs e)
    {
            DataSet ds = new DataSet();
            DataTable dt = getDT(formatDate);
            ds.Tables.Add(dt);
            GridView2.DataSource = ds.Tables["abc"].DefaultView;
            GridView2.DataBind();
        }
    
    }
    
    private DataTable getDT(string[] date)
    {
        DataTable dt = new DataTable("abc");
    
        dt.Columns.Add("RowID", typeof(Int16));
        dt.Columns.Add("Date", typeof(DateTime));
    
        for (int i = 0; i < date.Length; i++)
        {
            dt.Rows.Add(i + 1, date[i]);
        }
        return dt;
    }
