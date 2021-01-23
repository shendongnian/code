    protected void Page_Load(object sender, EventArgs e)
    {                        
      if(!Page.IsPostBack)
      {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Equipment ORDER by BLDG", conn);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                View_Results.DataSource = ds;
                View_Results.DataBind();
                conn.Close();
      }
    }
