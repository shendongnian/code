    var reader2 = command.ExecuteReader();
    Response.Write("[");
    var firstRecord = true;
    while (reader2.Read())
    {
        if (!firstRecord)
            Response.Write(",");
        firstRecord = false;
        var json = Json.Encode(new{
            code = reader2[1].ToString(),
            Revenue = reader2[4].ToString()
        });
        Response.Write(json);
    }
    Response.Write("]");
