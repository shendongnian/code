    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ID = Convert.ToInt32(Request.QueryString["myID"]);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT NAME, DEPARTMENT, LOCATION from MyTable WHERE ID =  @ID", con);
            DataTable dt= new DataTable();
            da.SelectCommand.Parameters.AddWithValue("@ID", int.Parse(ID));
            da.Fill(dt);
            ddl_Name.SelectedValue = dt[0].Name;
            ddl_DEPARTMENT.SelectedValue = dt[0].DEPARTMENT;
            ddl_LOCATION.SelectedValue = dt[0].LOCATION;
        }   
    }
