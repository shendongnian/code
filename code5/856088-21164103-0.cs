    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {            
        //Fetch data from mysql database
        SqlConnection conn = new SqlConnection("server=localhost;uid=root;
             password=priya123;database=world;pooling=false;");
        conn.Open();
        string cmd = "select * from country limit 7";
        SqlDataAdapter dAdapter = new SqlDataAdapter(cmd, conn);
        DataSet ds = new DataSet();
        dAdapter.Fill(ds);
        dt=ds.Tables[0];
        //Bind the fetched data to gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName.Equals("detail"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string code = GridView1.DataKeys[index].Value.ToString();
            IEnumerable<DataRow> query = from i in dt.AsEnumerable()
                              where i.Field<String>("Code").Equals(code)
                               select i;
            DataTable detailTable = query.CopyToDataTable<DataRow>();
            DetailsView1.DataSource = detailTable;
            DetailsView1.DataBind();
        }
    }
