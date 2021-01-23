         SqlDataReader c = cmd.ExecuteReader();
        
        while (c.Read())
        {
           table.Rows.Add(c[0].ToString(),c[1].ToString(),c[1].ToString());
        }
     c.CLose();
     con.CLose();
     dataGridView1.DataSource = table.AsDataView();
