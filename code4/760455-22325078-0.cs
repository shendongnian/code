    SqlConnection con = new SqlConnection("Data Source=SureshDasari;Integrated Security=true;Initial Catalog=MySampleDB");
    
    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    {
    BindGridview();
    }
    }
    // This method is used to bind gridview from database
    protected void BindGridview()
    {
    con.Open();
    SqlCommand cmd = new SqlCommand("select TOP 4 CountryId,CountryName from Country", con);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds);
    con.Close();
    gvParentGrid.DataSource = ds;
    gvParentGrid.DataBind();
    
    }
    protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
    con.Open();
    GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
    int CountryId = Convert.ToInt32(e.Row.Cells[1].Text);
    SqlCommand cmd = new SqlCommand("select * from State where CountryID=" + CountryId, con);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds);
    con.Close();
    gv.DataSource = ds;
    gv.DataBind();
    }
    }
