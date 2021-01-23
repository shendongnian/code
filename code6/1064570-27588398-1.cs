       -- your INSERT statement:
       string query = "INSERT INTO UserInfo(ID, Pass, Email, BDYear, BDMonth, BDDay, FullName) " + 
                      "VALUES (@ID, @Pass, @Email, @BDYear, @BDMonth, @BDDay, @FullName);";
       
       -- define your connection to the database
       using (SqlConnection conn = new SqlConnection("server=.;database=test;Integrated Securiy=SSPI;"))
       -- define your SqlCommand
       using (SqlCommand cmd = new SqlCommand(query, conn))
       {
           -- define the parameters and set their values
           cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
           cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = Pass;
           cmd.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = Email;
           cmd.Parameters.Add("@BDYear", SqlDbType.Int).Value = BDYear;
           cmd.Parameters.Add("@BDMonth", SqlDbType.Int).Value = BDMonth;
           cmd.Parameters.Add("@BDDay", SqlDbType.Int).Value = BDDay;
           cmd.Parameters.Add("@Fullname", SqlDbType.VarChar, 200).Value = Fullname;
           
           -- open connection, execute query, close connection
           conn.Open();
           
           int rowsAffected = cmd.ExecuteNonQuery();
           
           conn.Close();
       }
