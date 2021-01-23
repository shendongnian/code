    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {                
            BindData();                
        }
    }
    
    private void BindData()
    {
        DataTable dt = new DataTable();
    
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            string strQuery = "SELECT * FROM SampleTabL";
            SqlCommand cmd = new SqlCommand(strQuery);
    
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    Gridview1.DataSource = dt;
                    Gridview1.DataBind();
                }
                else
                {
                    SetInitialRow();
                }
            }
        }
    }
