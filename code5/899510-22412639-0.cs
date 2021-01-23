    protected void Page_Load(object sender, EventArgs e)
    {
        string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection objsqlconn = new SqlConnection(con);
        objsqlconn.Open();
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 pic1 From pictable", objsqlconn);
        string path = cmd.ExecuteScalar().ToString();
        slidediv.Attributes["style"] = String.Format("background-image:url('{0}')", path);
        objsqlconn.Close();
    }
