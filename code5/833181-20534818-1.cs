    NetworkStream passiveConnection;
    FileInfo fileParse = new FileInfo(openFileDialog.FileName);
    using(FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
    {
         byte[] buf = new byte[8192];
         int read;
         passiveConnection = createPassiveConnection();
         string cmd = "STOR " + fileParse.Name + "\r\n";
         tbStatus.Text += "\r\nSent:" + cmd;
         string response = sendFTPcmd(cmd);
         tbStatus.Text += "\r\nRcvd:" + response;
         while ((read = fs.Read(buf, 0, buf.Length) > 0)
         {
             passiveConnection.Write(buf, 0, read);
         }
    }
    passiveConnection.Close();
    MessageBox.Show("Uploaded");
    tbStatus.Text += "\r\nRcvd:" + new
    StreamReader(NetStrm).ReadLine(); 
    getRemoteFolders();
