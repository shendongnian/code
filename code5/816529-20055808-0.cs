     public List<string> getfiles(string FTPhostname, string FTPpath,string FTPusername,string FTPpassword,string extension)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + FTPhostname + "/" + FTPpath );
            ftpRequest.Credentials = new NetworkCredential(FTPusername , FTPpassword );
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory; 
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            List<string> results = new List<string>();
            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                if (line.Contains(extension)) {
                    line = streamReader.ReadLine();
                    results.Add(line);}
                else {line = streamReader.ReadLine(); }
                               }
            streamReader.Close();
            return results;
        }
          
