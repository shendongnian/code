    using System;
    using System.IO;
    using System.Net;
    
    ...
    
    // Register FtpWebRequest for the specified schema.
    WebRequest.RegisterPrefix("ftp://", ComponentPro.Net.FtpWebRequest.Creator);
    
    Console.WriteLine("Sending request...");
    
    // Create a WebRequest for the specified URL.
    WebRequest request = WebRequest.Create("ftp://ftp.example.net/pub/myfile.zip");
    
    // Send the WebRequest and waits for a response.
    WebResponse response = request.GetResponse();
    
    // Get remote file stream for downloading.
    Stream remoteFileStream = response.GetResponseStream();
    
    Stream localFileStream = File.Create("myfile.zip");
    
    // Create a new buffer to download.
    byte[] buffer = new byte[1024];
    int n;
    do
    {
        // Read data from the remote file stream.
        n = remoteFileStream.Read(buffer, 0, buffer.Length);
        // Write to the local file stream.
        localFileStream.Write(buffer, 0, n);
    } while (n > 0);
    
    Console.WriteLine("Response Received.");
    
    localFileStream.Close();
    
    // Release the resources of the response.
    remoteFileStream.Close();
