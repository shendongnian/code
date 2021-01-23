    using (var conn = new System.Data.SqlClient.SqlConnection("Server=LOCALHOSTDatabase=Lab1;Trusted_Connection=True;"))
    {
        conn.Open();
        using (var cmd = new SqlCommand("Delete From Student", conn))
        {
            cmd.ExecuteNonQuery();
        }
        using (var cmd = new SqlCommand("INSERT INTO Lines (Name) VALUES (@Name)", conn))
        {
            for (int i = 0; counter >= i; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", studentList[i]);
                cmd.ExecuteNonQuery();
            }
            counter++;
        }
    }
