    List <string> l1=new List <string>();
    
             SqlDataReader c = cmd.ExecuteReader();
            
            while (c.Read())
            {
               l1.Add(c[0].ToString());
            }
         c.CLose();
         con.CLose();
         Messabox.Show(li.Count.ToString());
         return;
         dataGridView1.DataSource = table.AsDataView();
