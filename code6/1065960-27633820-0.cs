    using(SqlConnection con = new SqlConnection(connString))
    using(SqlCommand cmd = con.CreateCommand())
    {
       cmd.CommandText = @"UPDATE Tb_Registration SET Country = @Country, City = @City
                           Where Username = @Username";
       cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
       cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text.Trim();
       cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = txtCity.Text.Trim();
       con.Open();
       cmd.ExecuteNonQuery();
    }
