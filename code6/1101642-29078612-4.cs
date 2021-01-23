    using (System.IO.FileStream stream = new System.IO.FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                               // start service client
                    CalculationServiceClient client = new CalculationServiceClient();     
    
                    RemoteFileInfo remoteFileInfo = new RemoteFileInfo(); ;
                    remoteFileInfo.FileName = TextBox1.Text;
                    remoteFileInfo.FileByteStream = stream;
    
                    // upload file
                    client.StartUpload(remoteFileInfo);
    
                    // close service client
                    client.Close();
                    uploadStream.Close();
                }
            }
