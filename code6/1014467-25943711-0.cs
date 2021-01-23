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
             cmd.CommandText = sb.ToString();
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
