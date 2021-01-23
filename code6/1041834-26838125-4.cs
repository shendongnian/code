    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        uploadftp.upload(@"c:\temp\FtpTestFile.txt", false, (BackgroundWorker)sender);
    }
    public void upload(string filename, 
                       bool uploadtosubortoroot, 
                       BackgroundWorker bworker)
    {
        try
        {
            //I assume your progressbar.MaxValue = 100
            bworker.ReportProgress(0);
            FtpWebRequest request = null;
            if (uploadtosubortoroot == true)
            {
                request = (FtpWebRequest)FtpWebRequest.Create(
                host + "/" + directory + "/" + Path.GetFileName(filename));
            }
            else
            {
                request = (FtpWebRequest)FtpWebRequest.Create(
                host + "/" + Path.GetFileName(filename));
            }
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(user, pass);
            bworker.ReportProgress(20);
            StreamReader sourceStream = new StreamReader(filename);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            bworker.ReportProgress(50);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
            response.Close();
            bworker.ReportProgress(100);
        }
        catch (Exception err)
        {
            string t = err.ToString();
        }    
    }
