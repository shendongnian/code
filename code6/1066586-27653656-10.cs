    public void ListDirectory(FtpClient client, string path, Action<string> action) 
    { 
          // stuff
          action(item.FullName)
          // stuff
          ListDirectory(client, item.FullName, action); 
    }
