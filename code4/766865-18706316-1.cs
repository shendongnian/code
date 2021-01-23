    var records = new List<CustomRecord>();
    while (reader2.Read())
    {
        records.Add(new CustomRecord {
            code = reader2[1].ToString(),
            Revenue = reader2[4].ToString()
        });
    }
    Response.Write(Json.Encode(records));
