        WebRequest MessageRequest;
        WebResponse MessageResponse;
        string jsonString = @"{ ""contacts"":""ValidNumber"",""text"":""test text""}";
        MessageRequest = WebRequest.Create(URL);
        MessageRequest.Method = "POST";
        MessageRequest.ContentType = "application/json";
        using (var strWrt = new StreamWriter(MessageRequest.GetRequestStream()))
        {
            strWrt.Write(jsonString);
            strWrt.Close();
        }
        MessageResponse = MessageRequest.GetResponse();
        return MessageResponse;
