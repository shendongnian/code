    public void Update()
    { 
      lock(lockObject)
      {
        if(CheckForInternetConnection())
        {
          if (DownloadFile(uri,path))
          {
            char[] charsToTrim = { '\r', '\n' };
            string onlineFile = File.ReadAllText(path).TrimEnd(charsToTrim);
            if (onlineConfigFile.Equals("") || onlineConfigFile == null)
              MessageBox.Show("Downloaded file is empty");
           //still do stuff here regardless of the message
           //If the other user really do intend to delete the list
          }
        }
      }
    }
