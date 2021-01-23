        static public void GetFileList(List<string> list,string sroot)
        {
            
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Host+sroot));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(Username, Password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails ;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                string file;
                while (!reader.EndOfStream ) 
                {
                    if (line.StartsWith("-"))
                    {
                        file = sroot + "/" + line.Substring(57);
                        list.Add(file);
                    }
                    else if (line.StartsWith("d"))
                    {
                        file = sroot + "/" + line.Substring(57);
                        list.Add(file+"/");
                        GetFileList(list, file);
                    }
                    line = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return;
        }
