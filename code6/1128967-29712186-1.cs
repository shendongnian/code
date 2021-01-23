      /// <summary>
    /// 从ftp服务器上获得文件夹列表
    /// </summary>
    /// <param name="RequedstPath">服务器下的相对路径</param>
    /// <returns></returns>
    public static List<string> GetDirctory(string RequedstPath)
    {
        List<string> strs = new List<string>();
        try
        {
            string uri = path + RequedstPath;   //目标路径 path为服务器地址
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            // ftp用户名和密码
            reqFTP.Credentials = new NetworkCredential(username, password);
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            WebResponse response = reqFTP.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());//中文文件名
    
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line.Contains("<DIR>"))
                {
                    string msg = line.Substring(line.LastIndexOf("<DIR>")+5).Trim();
                    strs.Add(msg);
                }
                line = reader.ReadLine();
            }
            reader.Close();
            response.Close();
            return strs;
        }
        catch (Exception ex)
        {
            Console.WriteLine("获取目录出错：" + ex.Message);
        }
        return strs;
    }
