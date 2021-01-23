    static public void UploadFiles(string [] files)
        {
            string host = " fts-sftp.myhost.com";
            string userName = "user";
            string password = "pass";
            var keyboardAuthMethod = new KeyboardInteractiveAuthenticationMethod(userName);
            keyboardAuthMethod.AuthenticationPrompt += delegate(Object senderObject, AuthenticationPromptEventArgs eventArgs)
            {
                foreach (var prompt in eventArgs.Prompts)
                {
                    if (prompt.Request.Equals("Password: ", StringComparison.InvariantCultureIgnoreCase))
                    {
                        prompt.Response = password;
                    }
                }
            };
            var passwordAuthMethod = new PasswordAuthenticationMethod(userName, password);
            var connectInfo = new ConnectionInfo(host, userName, passwordAuthMethod, keyboardAuthMethod);
            using (SftpClient serverConnection = new SftpClient(connectInfo))
            {
                try
                {
    foreach (var file in files)
    {
        if (!file.Name.StartsWith("."))
        {
            string remoteFileName = file.Name;
            if (file.LastWriteTime.Date == DateTime.Today)
            Console.WriteLine(file.FullName);
            File.OpenWrite(localFileName);
            string sDir = @"localpath";
            Stream file1 = File.OpenRead(remoteDirectory + file.Name);
            sftp.DownloadFile(remoteDirectory, file1);
        }
                    serverConnection.Disconnect();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
