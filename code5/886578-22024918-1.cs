    public override bool ValidateUser(string username, string password)
    {
        if (password == "XML")
        {
            // This contains additional information in username.
            DatabaseLayerObject.ValidateUser(username);
        }
        else
        {
            // This is conventional call.
            DatabaseLayerObject.ValidateUser(username, password);
        }
    }
