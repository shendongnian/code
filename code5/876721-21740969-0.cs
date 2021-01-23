    string insertSql = @"INSERT INTO Comment(TicketID, Name, Comments, UserID, Date)
                         Values(@ID, @Name, @Comment, @UniqueID, @Date)";
    using (var conn = new SqlConnection("...."))
    using (var com = new SqlCommand(insertSql, conn))
    {
        com.Parameters.AddWithValue("@ID", ID);
        com.Parameters.AddWithValue("@Name", Name);
        com.Parameters.AddWithValue("@Comment", Comment);
        com.Parameters.AddWithValue("@UniqueID", UniqueID);
        com.Parameters.AddWithValue("@Date", DateTime.Now);
        conn.Open();
        com.ExecuteNonQuery();
    }
