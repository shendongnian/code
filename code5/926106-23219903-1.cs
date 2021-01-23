    DateTime dt;
    if (DateTime.TryParseExact(txtBirthdate.Text, "yyyy-dd-MM", CultureInfo.InvariantCulture, DateTimeStyles.None,out dt))
    {
         var insert = "INSERT INTO Date_Master(BirthDate) VALUES(@birthdate)";
         using (SqlCommand cmd = new SqlCommand(insert, yourConnection))
         {
             cmd.CommandType = CommandType.Text;     
             cmd.Parameters.AddWithValue("@birthdate",dt);
             cmd.Connection.Open();
             cmd.ExecuteNonQuery();                  
          }
     }
