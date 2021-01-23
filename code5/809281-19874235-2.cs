     con.Open();
     SqlCeTransaction tx = conn.BeginTransaction();
     SqlCeCommand cmd1 = con.CreateCommand();
     cmd1.Transaction = tx;
     for (int i = 0; i < table.Rows.Count; i++)
     {
         cmd1.CommandText = "Insert into Master values('" + table.Rows[i].ItemArray[0].ToString() + "')";
         cmd1.ExecuteNonQuery();
     }
     tx.Commit();
     con.Close();
