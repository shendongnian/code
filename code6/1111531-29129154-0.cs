    using(SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            if (string.Equals(combomedicine.SelectedItem.ToString(), 
                              reader.GetValue(0).ToString(), 
                              StringComparison.InvariantCultureIgnoreCase)
            {
                combocompany.Items.Add(reader.GetValue(1).ToString());
                break;
            }
        }
    }
