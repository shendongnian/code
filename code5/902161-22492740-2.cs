    var dict = new Dictionary<object, Record>();
    using(var reader = cmd.ExecuteReader())
    {
        while(reader.Read())
        {
            object key = reader[0];
            Record rec = new Record(key);
            for(int i=0; i< reader.FieldCount; i++)
            {
                rec.Fields.Add(reader[i]);
            }
            dict.Add(key, rec);
        }
    }
