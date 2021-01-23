     MySqlDataAdapter [] all_adapters = new MySqlDataAdapter[2];
     DataTable [] data_tables = new DataTable[2];
    for (int i = 0; i < 2; i++ )
    {
        all_adapters[i] = new MySqlDataAdapter(query[i], connection);
        MySqlCommandBuilder cb = new MySqlCommandBuilder(all_adapters[i]);
        all_adapters[i].InsertCommand = cb.GetInsertCommand();
    
        data_tables[i] = new DataTable();
        all_adapters[i].Fill(data_tables[i]);
    }
     
    MySqlTransaction transaction = connection.BeginTransaction();
    try
    {
        for (int i = 0; i < 2; i++ )
        {
             all_adapters[i].InsertCommand.Transaction = transaction;
             if (i == 0)
             {
                  ... Add entry in table-1
                  // Fetch new auto_increment primary key of table-1
                  string new_query = "SELECT LAST_INSERT_ID();";
                  MySqlCommand cmd = new MySqlCommand(new_query, connection);
                  int primary_id_table1 = Convert.ToInt32(cmd.ExecuteScalar());
             }
            else 
            {
                 ... Add entry in table-2.
                 Use primary_id_table1 to populate the foreign key in table-2
            }
        }
        transaction.Commit();
    }
    catch (Exception e)
    {
         transaction.Rollback();
    }
