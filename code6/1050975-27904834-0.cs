    public void DownloadFromFTP( string ftpLocation, string fileName, string localFolder, string login, string password )
    {
    	var remoteFilePath = ftpLocation + @"/" + fileName;
    
    	FtpWebResponse response = null;
    
    	try
    	{
    		var request = (FtpWebRequest)WebRequest.Create( new Uri( remoteFilePath ) );
    		request.Method = WebRequestMethods.Ftp.DownloadFile;
    		request.Credentials = new NetworkCredential( login, password );
    
    		response = (FtpWebResponse)request.GetResponse();
    
    		var stream = response.GetResponseStream();
    
    		var localPath = string.Format( @"{0}\{1}", localFolder, fileName );
    
    		using( var fs = File.Create( localPath ) )
    		{
    			stream.CopyTo( fs );
    		}
    	}
    	catch( Exception ex )
    	{
    		throw ex;
    	}
    	finally
    	{
    		if( response != null )
    		{
    			response.Close();
    		}
    	}
    }
