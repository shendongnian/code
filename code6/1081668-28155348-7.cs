    string detailsQuery = "select * FROM [Customer] where Customer_No ='" + Session["New"] + "'";
    SqlCommand com = new SqlCommand(detailsQuery);
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    CustomerDetailsGV.DataSource = GetDataTable(com, con);
    CustomerDetailsGV.DataBind();
