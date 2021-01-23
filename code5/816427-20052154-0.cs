    	private void DownloadFileFTP(string fileName, string localFilePath, bool isXmlSchema)
    {
		FileStream fs = null;
		
		try
		{
			fileName = Regex.Replace(fileName.ToString(), @"\s.*$", "").Trim();
			
			string ftpFilePath = redacted;
			
			if (isXmlSchema)
			{
				ftpFilePath = ftpFilePath + fileName;
				label3.Text = "Fetching update information...";
			}
			else
			{
				ftpFilePath = ftpFilePath + Properties.Settings.Default.Customer + "/" + fileName;
				label3.Text = "Updating " + fileName;
			}
			
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
			request.Credentials = new NetworkCredential(redacted, redacted);
			request.Method = WebRequestMethods.Ftp.DownloadFile;
			request.EnableSsl = Properties.Settings.Default.SSL;
			request.UsePassive = Properties.Settings.Default.Passive;
			
			int bytesRead = 0;
			int bufferSize = 2048;
			byte[] buffer = new byte[bufferSize];
			
			Stream reader = request.GetResponseStream();
			
			bytesRead = reader.Read(buffer, 0, bufferSize);
			fs = new FileStream(localFilePath, FileMode.Create);
			
			while (bytesRead > 0)
			{
				fs.Write(buffer, 0, bytesRead);
				bytesRead = reader.Read(buffer, 0, bufferSize);
			}
			
			reader.Close();
			request.Close();
		}
		catch (Exception ex)
		{
			label3.Text = "Error: " + ex.ToString;
		}
		finally
		{
			if (fs != null)
			{
				fs.Close();
			}
		}
    }
