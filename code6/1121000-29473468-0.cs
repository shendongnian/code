    client.DownloadStringCompleted += (sender, e) =>
    {
        string selectedUserId = null;
        var users = JsonConvert.DeserializeObject<User[]>(e.Result.ToString());
        foreach (User user in users)
        {
            if (user.UName == selecteduser)
            {
                selectedUserId = user.UserID;
                break;
            }
        }
        
        HandleSelectedUserId(selectedUserId);
    };
    client.DownloadStringAsync(new Uri("http://some.url"));
