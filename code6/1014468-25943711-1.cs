     using (var conn = new SqlConnection("..."))
     {
         var sb = new StringBuilder("SELECT * FROM table1 WHERE");
         using (var cmd = new SqlCommand { Connection = conn })
         {
             if (!String.IsNullOrEmpty(comboBox1.Text))
             {
                 sb.Append(" id = @ID");
                 cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
             }
             if (!String.IsNullOrEmpty(comboBox2.Text))
             {
                 sb.Append(" name = @NAME");
                 cmd.Parameters.AddWithValue("@NAME", comboBox2.Text);
             }
             var query = sb.ToString();
             cmd.CommandText = query.EndsWith("WHERE") ? query.Remove(query.Length - 5) : query;
             conn.Open();
             using (var reader = cmd.ExecuteReader())
             {
                 while (reader.Read())
                 {
                     // do whatever you need to do with your data
                 }
             }
         }
     }
