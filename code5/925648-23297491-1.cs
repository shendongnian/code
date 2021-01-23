       public void Main()
    {
	FtpSystem ftp = new FtpSystem();
	if (ftp.DirectoryExist("p")) {
		Console.WriteLine("false");
	} else {
		Console.WriteLine("true");
	}
	Console.ReadLine();
    }
    private class FtpSystem
    {
	public object DirectoryExist(string dir)
	{
		Uri uri = new Uri("ftp://domain.com" + "/" + dir);
		NetworkCredential netCred = new NetworkCredential("user", "password");
		FtpWebRequest ftprq = FtpWebRequest.Create(uri);
		var _with1 = ftprq;
		_with1.Credentials = netCred;
		_with1.KeepAlive = true;
		_with1.Method = WebRequestMethods.Ftp.ListDirectory;
		_with1.UsePassive = true;
		_with1.UseBinary = false;
		FtpWebResponse ftprs = null;
		StreamReader Sr = null;
		//if ftp try to matching folder ad if it will succeed then return true if not it will thrown an exception 
		//and it will return false. Is not a good way because it should be implement a very granular exception matching but 
		//for test is best simple approach.
		try {
			ftprs = (FtpWebResponse)ftprq.GetResponse;
			Sr = new StreamReader(ftprs.GetResponseStream);
			string T = Sr.ReadToEnd;
			Console.Write(T);
			return true;
		} catch (Exception ex) {
			return false;
		}
	    }
    }
