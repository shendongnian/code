    var reader = new JsonTextReader(new StringReader(jsonString));
    var response = new GetRoomListResponse();
    var currentProperty = string.Empty;
    while (reader.Read())
    {
        if (reader.Value != null)
        {
            if (reader.TokenType == JsonToken.PropertyName)
                currentProperty = reader.Value.ToString();
            if (reader.TokenType == JsonToken.Integer && currentProperty == "Acknowledge")
                response.Acknowledge = (AcknowledgeType)Int32.Parse(reader.Value.ToString());
            if (reader.TokenType == JsonToken.Integer && currentProperty == "Code")
                response.Code = Int32.Parse(reader.Value.ToString());
            if (reader.TokenType == JsonToken.String && currentProperty == "Message")
                response.Message = reader.Value.ToString();
            if (reader.TokenType == JsonToken.String && currentProperty == "Exception")
                response.Exception = reader.Value.ToString();
            // Process Rooms and other stuff
        }
        else
        {
            // Process tracking the current nested element
        }
    }
