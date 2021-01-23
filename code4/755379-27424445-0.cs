        System.Net.FtpWebRequest ftpRequest =    System.Net.FtpWebRequest)System.Net.WebRequest.Create(SourceDirectory);
                ftpRequest.Credentials = new System.Net.NetworkCredential(SourceFTPUserName, SourceFTPPassword);
                   ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                  System.Net.FtpWebResponse response =        (System.Net.FtpWebResponse)ftpRequest.GetResponse();
            System.IO.StreamReader streamReader = new System.IO.StreamReader(response.GetResponseStream());
            List<string> directories = new List<string>();
            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            return directories;
