    int itemCodeOrdinal = reader.GetOrdinal("ItemCode");
    while (reader.Read())
    {
        comboBox1.Items.Add(reader.GetString(itemCodeOrdinal));
        comboBox2.Items.Add(reader.GetString(itemCodeOrdinal));
    }
