    List<Template> result = new List<Template>();
    // Password
    string[] Password_Array = TemplateModel.Password.Split(',');
    // User
    string[] User_Array = TemplateModel.User.Split(',');
    for (int i = 0; i < User_Array.Length; i++)
    {
        string[] users = User_Array[i].Split(';');
        // stop it blowing up if there are fewer passwords than usernames 
        // given that we are indexing against the username array
        string password = string.Empty;
        if (Password_Array.Length > i) {
            string[] passwords = Password_Array[i].Split(';');
            password = passwords[0];
        }
        
        result.Add(new Template { User = users[0], Password = password });
    }
