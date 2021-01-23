    protected void Page_load(object sender,EventArgs e)
    {
    System.Data.Odbc.OdbcConnection conn=new OdbcConnection("DSN=mydsn");
    OdbcDataAdapter ad=new OdbcDataAdapter("select * from mylist",conn);
    DataSet ds=new DataSet();
    ad.Fill(ds);
    GridView1.DataSource=ds;
    GridView1.DataBind();
    
    }
