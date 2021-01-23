    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        uploadftp.upload(@"c:\temp\FtpTestFile.txt", false, (BackgroundWorker)sender);
    }
    public void upload(string filename, bool uploadtosubortoroot, BackgroundWorker bworker)
    {
        try
        {
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
            
            bworker.ReportProgress(0, "Create uploading data...");
            StreamReader sourceStream = new StreamReader(filename);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            bworker.ReportProgress(50, "Uploading file...");
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
            response.Close();
            
        }
        catch (Exception err)
        {
            string t = err.ToString();
        }    
    }
