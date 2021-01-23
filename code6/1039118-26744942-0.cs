    if(!IsPostBack){
        string query = @"SELECT * FROM FORMULA";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BancoEstadoConnectionString"].ToString()))
        {
            SqlCommand comand = new SqlCommand(query, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            
            adp.Fill(ds);
            
            Select1.DataSource = ds;
            Select1.DataTextField = "au_fname";
            Select1.DataValueField = "au_fname";
            Select1.DataBind();
        }
    } 
