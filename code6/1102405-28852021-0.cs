    using (SqlConnection con = new SqlConnection("YourConnectionString")) 
    {
     using (SqlCommand cmd = new SqlCommand("INSERT INTO MyTable(FirstColumn, SecondColumn) VALUES(@FirstValue, @SecondValue)", con))
      {
         cmd.Parameters.Add("@FirstValue", SqlDbType.VarChar, 20).Value = "SomeValue";
         cmd.Parameters.Add("@SecondValue", SqlDbType.VarChar, 20).Value = "SomeValue";
          ...
         con.Open();
         cmd.ExecuteNonQuery();
      }
    } //Connection will get disposed here
