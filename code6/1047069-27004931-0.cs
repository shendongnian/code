    private void UploadFiles()
    {
		string filename = Server.MapPath("file1.txt");
		string ftpServerIP = "ftp.demo.com/";
		string ftpUserName = "dummy";
		string ftpPassword = "dummy";
		FileInfo objFile = new FileInfo(filename);
		FtpWebRequest objFTPRequest;
		// Create FtpWebRequest object 
		objFTPRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + objFile.Name));
		// Set Credintials
		objFTPRequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
		// By default KeepAlive is true, where the control connection is 
		// not closed after a command is executed.
		objFTPRequest.KeepAlive = false;
		// Set the data transfer type.
		objFTPRequest.UseBinary = true;
		// Set content length
		objFTPRequest.ContentLength = objFile.Length;
		// Set request method
		objFTPRequest.Method = WebRequestMethods.Ftp.UploadFile;
		// Set buffer size
		int intBufferLength = 16 * 1024;
		byte[] objBuffer = new byte[intBufferLength];
		// Opens a file to read
		FileStream objFileStream = objFile.OpenRead();
		try
		{
			// Get Stream of the file
			Stream objStream = objFTPRequest.GetRequestStream();
			int len = 0;
			while ((len = objFileStream.Read(objBuffer, 0, intBufferLength)) != 0)
			{
				// Write file Content 
				objStream.Write(objBuffer, 0, len);
			}
			objStream.Close();
			objFileStream.Close();
		}
		catch (Exception ex)
		{
			throw ex;
		}
    }
