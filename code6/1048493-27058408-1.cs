    using(SqlConnection con = new SqlConnection(conString))
    using(SqlCommand cmd = con.CreateCommand())
    {
       cmd.CommandText = "INSERT INTO Test (Id, Name) VALUES (@Id, @Name)";
       cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 1;
       cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = "Myname";
       // I assumed your column types are Int and NVarChar
       con.Open();
       cmd.ExecuteNonQuery();
    }
