    protected void Bind_DD()
    {
        string myVar;
        myVar= My_DD.SelectedValue.ToString();
        string ID;
        ID = Request.QueryString["ID"];
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand("sp_DD");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@My_DD", SqlDbType.VarChar).Value = My_DD;
        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        My_DD.Items.Clear();
        My_DD.DataSource = dt;
        My_DD.DataBind();
    }
