    using (SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Traindata.mdf;Integrated Security=True"))
    {
        using (SqlCommand command = SqlCommand.CreateCommand())
        {
            try
            {
                conn.Open();
                command.Query = "select count(*) from dbo.Station";
                Int32 rowsRet = command.ExecuteNonQuery();
                command.Query = "INSERT INTO dbo.Station (Naam, X, Y, Sporen) VALUES (@naam, @x, @y, @sporen)";
                command.Parameters.AddWithValue("@naam", insert[1]);
                command.Parameters.Add("@x", SqlDbType.Int);
                command.Parameters["@x"].Value = Int32.Parse(insert[2]);
                command.Parameters.Add("@y", SqlDbType.Int);
                command.Parameters["@y"].Value = Int32.Parse(insert[3]);
                command.Parameters.AddWithValue("@sporen", insert[4]);
          
                rowsRet = command.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                Console.WriteLine("Error to save on database");
                Console.WriteLine(exc.Message);
            }
            finally 
            {
                conn.Close();
            }
        }
    }
