    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string constr = ConfigurationManager.ConnectionStrings["sacpConnectionString"].ToString(); 
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            ......
        }
    }
