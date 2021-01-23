     ds.Tables[0].Rows.Add(newRow);
     SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adp);
     adp.DeleteCommand = commandBuilder.GetDeleteCommand(true);
     adp.UpdateCommand = commandBuilder.GetUpdateCommand(true);
     adp.InsertCommand = commandBuilder.GetInsertCommand(true);
     adp.Update(ds.Tables[0]);
     connection.UpdateDatabase(ds);
     connection.Close();
