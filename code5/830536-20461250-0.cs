    public void BindData()
    {
        string aPara = null;
        aPara = aUser.ID;
        clsDataConduit aConn = new clsDataConduit();
        aDataTable = new DataTable();
        aConn.AddParameter("@aPara", aPara);
        aDataTable = aConn.Return_aDataTable("an_user_sproc");
        GridView1.DataSource = aDataTable;
        GridView1.DataBind();
    
    }
