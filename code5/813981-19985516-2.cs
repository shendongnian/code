    var cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
    var gridSql = "Select top 10 FirstName, LastName, Address, City, State from Customers";
    var cntSql = "SELECT TOP 10 COUNT(CreditLimit) FROM Customers";
    
    using (SqlConnection con = new SqlConnection(cs))
    {
        con.Open();
    
        try
        {
            using (SqlCommand cmd = new SqlCommand(gridSql, con))
            {
                GridView1.DataSource = cmd.ExecuteReader(); 
                GridView1.DataBind();
            }
    
            using (SqlCommand cmd = new SqlCommand(cntSql, con))
            {
                int total = (int)cmd.ExecuteScalar();
                TotalCreditLble.Text = "The total Credit :" + total.ToString();
            }
        }
        catch(Exception exp)
        {
            Response.Write(exp.Message);
        }
    }
