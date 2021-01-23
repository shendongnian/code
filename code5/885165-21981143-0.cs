    foreach (decimal someVar in Dict.Values)
    {
      OleDbCommand command = myAccessConn.CreateCommand();
      OleDbTransaction trans = myAccessConn.BeginTransaction();
      command.Transaction = trans;
      command.CommandText = "SELECT COLUMN FROM my_tb2 WHERE ROW='" + someVar + "'";
      command.ExecuteNonQuery();
      nb = Convert.ToString(command.ExecuteScalar());
      comboBox2.Items.Add(nb;
      trans.Commit();
    }
