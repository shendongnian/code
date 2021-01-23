    openFileDialog1.ShowDialog();
    FileInfo feltoltfile = new FileInfo(openFileDialog1.FileName);
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpadress + "/" + feltoltfile.Name);
    request.Method = WebRequestMethods.Ftp.UploadFile;
    request.Credentials = new NetworkCredential(textBox1.Text, textBox2.Text);
    using (var sourceStream = feltoltfile.OpenRead())
    using (var requestStream = request.GetRequestStream())
    {
        long fileSize = request.ContentLength = feltoltfile.Length;
        long bytesTransfered = 0;
    
        byte[] buffer = new byte[4096];
        int read;
        while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0) //while there are still bytes to be copied
        {
            requestStream.Write(buffer, 0, read);
            requestStream.Flush();
            bytesTransfered += read;
            //trigger progress event...
        }
    }
    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
    {
        serverstatus.Items.Add(response.StatusDescription + " " + feltoltfile.Name + " --> " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
    }
    ftplista.Items.Clear();
    FTPlistalekerdezes(ftpadress, textBox1.Text, textBox2.Text);
    MessageBox.Show("Ready!");
