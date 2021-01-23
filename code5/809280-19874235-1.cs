     SqlCeCommand cmd1 = new SqlCeCommand();
     con.Open();
     cmd1.Connection = con;
     for (int i = 0; i < table.Rows.Count; i++)
     {
         cmd1.CommandText = "Insert into Master values('" + table.Rows[i].ItemArray[0].ToString() + "')";
         cmd1.ExecuteNonQuery();
     }
     con.Close();
