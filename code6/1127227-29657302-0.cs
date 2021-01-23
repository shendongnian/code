    String mobile = "";
    using (MySqlConnection conn = new MySqlConnection(mySqlConn)) {
                try
                {
                    conn.Open();
                    string queryString = "SELECT mobile FROM assignments 
           inner join Customers on assignments.Customer_ID = customers.Customer_ID";
                    MySqlCommand cmd = new MySqlCommand(queryString, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader()) {
                        while (rdr.Read())
                        {
                            mobile = rdr[0].ToString();
                        }
                    }
                }
                catch (Exception ex) {  }
            }
