    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            string detailsQuery = "select * FROM [Customer] where SessionID ='" + Session.SessionID + "'";
            SqlCommand com = new SqlCommand(detailsQuery, conn);
            com.ExecuteNonQuery();                
            Response.Write("Details Showing");
            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex.ToString());
        }
    }
