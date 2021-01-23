    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connecton1"].ConnectionString);
    conn.Open();
    SqlCommand check = new SqlCommand("SELECT Location FROM Items WHERE Serial           ="+Convert.ToInt32(Serialtxt.Text).ToString()+"", conn);
    SqlDataReader checker = check.ExecuteReader();
        while (checker.Read())
        {
               if (checker[0] != null)
               {
                  //some logic with the result
               }
        }
