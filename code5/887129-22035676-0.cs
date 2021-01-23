    System.Net.FtpWebRequest ftpReq = null;
    System.Net.FtpWebResponse ftpRes = null;
    try
    {
	ftpReq = System.Net.WebRequest.Create(path) as System.Net.FtpWebRequest;
	ftpReq.Credentials = new System.Net.NetworkCredential(user, password);
	ftpReq.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory;
	ftpReq.KeepAlive = false;
	ftpRes = ftpReq.GetResponse() as System.Net.FtpWebResponse;
	ftpRes.Close();
    }
    catch (WebException we)
    {
	
    }
    catch (Exception e)
    {	
    }
