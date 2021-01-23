    public void ListDirectory(FtpClient client, string path, Action<string> callback) 
    { 
          // stuff
          callback(item.FullName)
          // stuff
          ListDirectory(client, item.FullName, callback); 
    }
