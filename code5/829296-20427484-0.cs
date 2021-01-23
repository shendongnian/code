       request.Method = WebRequestMethods.Ftp.ListDirectory;
       request.Credentials = new NetworkCredential(userName, password);
       try
        {
            using (request.GetResponse())
            {
                //continue
            }
        }
        catch (WebException)
        {
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            using (request.GetResponse())
            {
                //continue
            }
        }
