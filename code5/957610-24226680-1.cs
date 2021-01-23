    [WebMethod()]
     public static string CheckShoseCodeAvailability(string shoseCode)
     {
                string availStatus = string.Empty;
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                str = "select count(*) from tblShoes where ShoesCode ='" + shoseCode + "'";
                com = new SqlCommand(str, con);
                int count = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
                if (count > 0)
                     availStatus = "2";
                else
                   availStatus = "1";
                
                return availStatus;
      }
