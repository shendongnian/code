    public void Connect(string fileName)
    {
        bool success;
        success = ftp.UnlockComponent("license");
        if (!success)
        {
            Console.WriteLine(ftp.LastErrorText);
            return;
        }
        ftp.IdleTimeoutMs = 10000;
        ftp.AuthTls = true;
        ftp.Ssl = false;
        ftp.Hostname = ftpUrl;
        ftp.Port = 21;
        ftp.Username = username;
        ftp.Password = password;
        ftp.KeepSessionLog = true;
        success = ftp.Connect();
        if (success != true)
        {
            Console.WriteLine(ftp.LastErrorText);
            return;
        }
        ftp.ClearControlChannel();
        bool sucess = ftp.GetFile("out/" + fileName, localFolder + fileName);
        if (!success)
        {
            Console.WriteLine(ftp.LastErrorText);
            AppendErrorLogFile("Error in downloading file", "Download file method", fileName);
            return;
        }
        else
        {
            AppendLogFile("Download Success", "Download File Method", fileName);
            ftp.DeleteRemoteFile("out/" + fileName);
        }
    }
