    public string LoadHtmlTableCustomerData()
    {
        SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
        string HTML = "";
        try
        {
            SqlCommand command = new SqlCommand("SELECT  * FROM tbl_Customers", connection);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                int count = 0;
                while (dr.Read())
                {
                    string lastname = dr[1].ToString();
                    string firstname = dr[2].ToString();
                    string middlename = dr[3].ToString();
                    string age = dr[4].ToString();
    
                    HTML += "<tr class=\"" + (count % 2 == 0 ? "white-row" : "green-row") + "\"><td>" + lastname + "</td><td>" + firstname + "</td><td>" + middlename + "</td><td>" + age + "</td></tr>";
                    count++;
                }
            }
        }
        catch (Exception) { }
        finally { connection.Close(); }
        return HTML;
    }
