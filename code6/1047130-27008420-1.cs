    public static string DownloadFile(string FilePath)
    {
       
        string SalesStatus = "ok";
        try
        {
           
            if (!File.Exists(FlagFilePath) &&  !IsDownloadInProgress)
            {
                Debug.WriteLine("Trying to download sales data file ");
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = ConfigurationManager.AppSettings["SFTPDomain"],
                    UserName = ConfigurationManager.AppSettings["SFTPUser"],
                    Password = ConfigurationManager.AppSettings["SFTPPass"],
                    PortNumber = Convert.ToInt32(ConfigurationManager.AppSettings["SFTPPortNumber"]),
                    GiveUpSecurityAndAcceptAnySshHostKey = true,
                };
                using (Session session = new Session())
                {
                 
                    //Attempts to connect to your SFtp site
                    session.Open(sessionOptions);
                    //Get SFtp File
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary; //The Transfer Mode - Automatic, Binary, or Ascii 
                    transferOptions.FilePermissions = null;  //Permissions applied to remote files; 
                    transferOptions.PreserveTimestamp = false;  //Set last write time of destination file 
                    //to that of source file - basically change the timestamp to match destination and source files.    
                    transferOptions.ResumeSupport.State = TransferResumeSupportState.On;
                    //SFTP File Path
                    Sftp_RemotePath = ConfigurationManager.AppSettings["SFTPFileName"].ToString();
                    //Delete File if Exist
                    if (System.IO.File.Exists(FilePath))
                    {
                        System.IO.File.Delete(FilePath);
                    }
           
                    //the parameter list is: remote Path, Local Path with filename 
                //    string result = Path.GetRandomFileName();
                   session.GetFiles(Sftp_RemotePath,FilePath,false,  transferOptions).Check();
                   
                    //Throw on any error 
                   session.FileTransferred += OnFileTransferComplete;
                   IsDownloadInProgress = true;
                    session.Dispose();
                  //  File.Move(FilePath, "foo2.png");
                    Debug.WriteLine("Downloaded fresh sales data file!");
                }
            }
        }
        catch (Exception ex)
        {
            string _errorMsg = "";
            // Setting Sales Status values
            if (ex.InnerException != null)
            {
                if (ex.InnerException.Message.Contains("Authentication failed"))
                {
                    _errorMsg = ex.InnerException.Message;
                    Debug.WriteLine("wrong username/password");
                    SalesStatus = "2";
                }
                else if (ex.InnerException.Message.Contains("No such file or directory"))
                {
                    _errorMsg = ex.InnerException.Message;
                    Debug.WriteLine("File is not Available");
                    SalesStatus = "3";
                }
            }
            else
            {
                _errorMsg = ex.Message;
                Debug.WriteLine("General SFTP Error");
                SalesStatus = "4";
            }
            //Create log error file
            if (!File.Exists(FlagFilePath))
            {
                // create SFTP LocalErrorFlag
                Debug.WriteLine("Creating SFTP flag file");
                System.IO.File.WriteAllText(FlagFilePath, "SFTP Error: " + _errorMsg);
            }
            else
            {
                Debug.WriteLine("SFTP error Flag file already exists");
            }
        }
        return SalesStatus;
    }
    private static void OnFileTransferComplete(object sender, TransferEventArgs e)
    {
        IsDownloadInProgress = false;
        ((Session)sender).FileTransferred -= OnFileTransferComplete;
    }
