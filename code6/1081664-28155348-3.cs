    string detailsQuery = "select * FROM [Customer] where Customer_No ='" + Session["New"] + "'";
    SqlCommand com = new SqlCommand(detailsQuery);
    DataTable dt = new DataTable();
    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
    {
        com.Connection = conn;
        conn.Open();                
        dt.Load(com.ExecuteReader());                       
    }
    CustomerDetailsGV.DataSource = dt;
    CustomerDetailsGV.DataBind(); 
