    var message = JToken.Parse("...").ToObject<Message>();
    
    if (message.Header.TypeName == "User")
    {
        var user = message.Body.ToObject<User>();
    }
    else if (message.Header.TypeName == "Answer")
    {
        var answer = message.Body.ToObject<Answer>();
    }
