    List<Trigger> TriggerValues = new List<Trigger>();
    
    while (reader.Read())
    {
        TriggerValues.Add(new Trigger(reader.GetString(0), reader.GetInt32(1)));
    }
