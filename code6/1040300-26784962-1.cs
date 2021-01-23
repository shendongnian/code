    public static void addStatue(string ID, string Name)
    {
        string strAddStatue = "Insert into Statues  VALUES (@ID, @Name)";
        using (var connection1 = Globalconnection.cn)
        {
            using (var cmdAddStatue = new SqlCommand(strAddStatue, connection1))
            {
                cmdAddStatue.Parameters.AddWithValue("@ID", ID);
                cmdAddStatue.Parameters.AddWithValue("@Name", Name);
                cmdAddStatue.ExecuteNonQuery(); 
            }
        }
    }
