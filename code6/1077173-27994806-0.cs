    var columns2 = listBox6;
    while (reader.Read())
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {    
            columns2.Items.Add(reader.GetValue(i).ToString());    
        }
    }
