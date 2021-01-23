    List<TextBox> texts = new List<TextBox> { textBox16, textBox17, textBox20 };
    foreach (var textBox in texts)
    {
       using (SqlConnection sqlCon2 = new SqlConnection("REMOVED"))
       {
           using (SqlCommand sqlCmd2 = new SqlCommand {CommandText = "INSERT INTO [Products].[Features] ([ProductID] ,[Title] ,[ViewOrder]) VALUES ('" + textBox15.Text + "', '" + textBox.Text + "', NULL) ", Connection = sqlCon2})
            {
                sqlCon2.Open();
                sqlCmd2.ExecuteNonQuery();
            }
       }
    }
