    public void GridViewBind()
    {
    sql1 = " SELECT * FROM `tbl` ORDER BY empid DESC; ";
    dadapter = new OdbcDataAdapter(sql1, myConnectionString);
    dset = new DataSet();
    dset.Clear();
    dadapter.Fill(dset);
    DataTable dt = new DataTable();
    dt=dset.Tables[0];
    DataView dv = dt.DefaultView;
    dv.Sort = "empid desc";
    DataTable sortedDT = dv.ToTable();
    GridView1.DataSource = sortedDT;
    GridView1.DataBind();
    dadapter.Dispose();
    dadapter = null;
    myConnectionString.Close();
    }
