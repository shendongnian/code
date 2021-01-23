        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.freebsd.org/pub/FreeBSD/");
            ftpRequest.Credentials = new NetworkCredential("anonymous", "k3rnel31@k.com");
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            List<string> filestxt = new List<string>();
            string line = streamReader.ReadLine();
             while (!string.IsNullOrEmpty(line))
            {
                line = streamReader.ReadLine();            
                if (line.ToLower().Contains(".txt"))
                {
                    filestxt.Add(line);
                    MessageBox.Show("txt file found : " + line.ToString());
                    
                }
                
            }
            streamReader.Close();
