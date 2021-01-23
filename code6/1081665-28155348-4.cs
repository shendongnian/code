    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    conn.Open();
    string detailsQuery = "select * FROM [Customer] where Customer_No ='" + Session["New"] + "'";
    SqlCommand com = new SqlCommand(detailsQuery, conn);
    DataTable dt = new DataTable();
    dt.Load(com.ExecuteReader());   
    CustomerDetailsGV.DataSource = dt;
    CustomerDetailsGV.DataBind();             
    conn.Close();
