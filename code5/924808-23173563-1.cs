    cmdReader = new MySqlCommand(query, conn);
    myReader = cmdReader.ExecuteReader();
    for(int index=0; index < reader.FieldCount; index++)
    {
       c.Items.Add(myReader.GetName(index));
    }
