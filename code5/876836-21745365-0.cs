    /// <summary>
    /// Methods to upload file to FTP Server
    /// </summary>
    /// <param name="_FileName">local source file name</param>
    /// <param name="_UploadPath">Upload FTP path including Host name</param>
    /// <param name="_FTPUser">FTP login username</param>
    /// <param name="_FTPPass">FTP login password</param>
    public void UploadFile(string _FileName, string _UploadPath, string _FTPUser, string _FTPPass)
    {
        System.IO.FileInfo _FileInfo = new System.IO.FileInfo(_FileName);
    
        // Create FtpWebRequest object from the Uri provided
        System.Net.FtpWebRequest _FtpWebRequest = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(new Uri(_UploadPath));
    
        // Provide the WebPermission Credintials
        _FtpWebRequest.Credentials = new System.Net.NetworkCredential(_FTPUser, _FTPPass);
    
        // By default KeepAlive is true, where the control connection is not closed
        // after a command is executed.
        _FtpWebRequest.KeepAlive = false;
    
        // set timeout for 20 seconds
        _FtpWebRequest.Timeout = 20000;
    
        // Specify the command to be executed.
        _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
    
        // Specify the data transfer type.
        _FtpWebRequest.UseBinary = true;
    
        // Notify the server about the size of the uploaded file
        _FtpWebRequest.ContentLength = _FileInfo.Length;
    
        // The buffer size is set to 2kb
        int buffLength = 2048;
        byte[] buff = new byte[buffLength];
    
        // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
        System.IO.FileStream _FileStream = _FileInfo.OpenRead();
    
        try
        {
            // Stream to which the file to be upload is written
            System.IO.Stream _Stream = _FtpWebRequest.GetRequestStream();
    
            // Read from the file stream 2kb at a time
            int contentLen = _FileStream.Read(buff, 0, buffLength);
    
            // Till Stream content ends
            while (contentLen != 0)
            {
                // Write Content from the file stream to the FTP Upload Stream
                _Stream.Write(buff, 0, contentLen);
                contentLen = _FileStream.Read(buff, 0, buffLength);
            }
    
            // Close the file stream and the Request Stream
            _Stream.Close();
            _Stream.Dispose();
            _FileStream.Close();
            _FileStream.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
