    Use this code: It works fine
    static void Main(string[] args)
    {
        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://mywebsite.com/");
        ftpRequest.Credentials = new NetworkCredential("user345", "pass234");
        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
        FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
        StreamReader streamReader = new StreamReader(response.GetResponseStream());           
        List<string> directories = new List<string>();            
        string line = streamReader.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {
            directories.Add(line);
            line = streamReader.ReadLine();
        }
        streamReader.Close();
        using (WebClient ftpClient = new WebClient())
        {
            ftpClient.Credentials = new System.Net.NetworkCredential("user345", "pass234");
            for (int i = 0; i <= directories.Count-1; i++)
            {
                if (directories[i].Contains("."))
                {
                    string path = "ftp://mywebsite.com/" + directories[i].ToString();
                    string trnsfrpth = @"D:\\Test\" + directories[i].ToString();
                    ftpClient.DownloadFile(path, trnsfrpth);
                }
            }
        }
