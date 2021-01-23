        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.freebsd.org/pub/FreeBSD/");
            ftpRequest.Credentials = new NetworkCredential("anonymous", "k3rnel31@k.com");
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            List<string> filestxt = new List<string>();
            string line = streamReader.ReadLine();
         while (!string.IsNullOrEmpty(line))
            {
                if (line.Contains(".txt")) {
     MessageBox.Show(line); 
    line = streamReader.ReadLine();
     filestxt.Add(line);} else { line = streamReader.ReadLine(); }
               
            }
                 
            streamReader.Close();
