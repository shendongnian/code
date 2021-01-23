    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = GridViewData;
            GridView1.DataBind();
        }
    }
    public DataSet GridViewData
    {
        get
        {
            if (ViewState["GridViewData"] == null)
            {
                String str = "select * from tblEmployee where (Name like '%' + @search + '%')";
                SqlCommand xp = new SqlCommand(str, objsqlconn);
                xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = TextBox1.Text;
                objsqlconn.Open();
                xp.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = xp;
                DataSet ds = new DataSet();
                da.Fill(ds, "Name");
                objsqlconn.Close();
                ViewState["GridViewData"] = ds;
            }
            return (DataSet)ViewState["GridViewData"];
        }
    }
