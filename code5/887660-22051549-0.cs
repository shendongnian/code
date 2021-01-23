    using (FtpConnection ftp = new FtpConnection(host, _params.Username, _params.Password))
    {
                try
                {
                    ftp.Open(); /* Open the FTP connection */
                    ftp.Login(); /* Login using previously provided credentials */
                    ftp.PutFile(_params.SourceFilename, _params.TargetFilename); /* upload /incoming/file.txt as file.txt to current executing directory, overwrite if it exists */
                    if (!ftp.DirectoryExists(_params.FinalDir)) /* check that a directory exists */
                    {
                        ftp.CreateDirectory(_params.FinalDir);
                    }
                    if (ftp.FileExists(_params.FinalLocation))
                    {
                        ftp.RemoveFile(_params.FinalLocation);
                    }
                    ftp.RenameFile(target, _params.FinalLocation);
                    statusDict[StatusEnum.ftpStatus] = Constants.SUCCESS_STATUS;
                }
                catch (Exception ex)
                {
                    statusDict[StatusEnum.ftpStatus] = Constants.ERROR_STATUS;
                }
            }
