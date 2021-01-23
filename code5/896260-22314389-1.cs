           // Here I have just finished using JSON to extra info from a JSON response
        if (success.EndsWith("rue"))
        {
            if (!myUserSettings.Contains("userLoggedIn"))
            {
                myUserSettings.Add("userLoggedIn", success);
            }
            else
            {
                myUserSettings["userLoggedIn"] = success;
            }
            if (!myUserSettings.Contains("username"))
            {
                myUserSettings.Add("username", username);
            }
            else
            {
                myUserSettings["username"] = username;
            }
            if (!myUserSettings.Contains("password"))
            {
                myUserSettings.Add("password", password);
            }
            else
            {
                myUserSettings["password"] = password;
            }
            if (!myUserSettings.Contains("fullAccess"))
            {
                myUserSettings.Add("fullAccess", fullAccess);
            }
            else
            {
                myUserSettings["fullAccess"] = fullAccess;
            }
            myUserSettings.Save();
            
    
