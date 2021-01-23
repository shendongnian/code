    using (var connection = new SqlConnection(ProjectConnectionString))
    {
        connection.Open();
    
        foreach (var li in ListBox1.Items.Cast<ListItem>().Where(x => x.Selected))
        {
            using (var command = connection.CreateCommand())
            {
                command.CommantText =
                    "UPDATE [Login_det] SET Enabled = 0 WHERE Name = @UserName";
    
                command.Parameters.AddWithValue("UserName", li.Value);
                command.ExecuteNonQuery();
            }
        }
    }
