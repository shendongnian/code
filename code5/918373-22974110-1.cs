    JsonObjectContainer ar = new JsonObjectContainer();
    ar.AuthenticateResponse.StatusMessage = "Test status Message";
    ar.AuthenticateResponse.IlsMessage = "Test IlsMessage";
    ar.AuthenticateResponse.IlsCode = "Code 614";
    string json = JsonConvert.SerializeObject(ar);
