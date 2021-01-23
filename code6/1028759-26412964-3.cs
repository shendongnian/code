    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
	HttpWebResponse response = req.GetResponse();
    //check the filetype returned
    string contentType = response.ContentType;
	if(contentType!=null)
	{
		splitString = contentType.Split(';');
		fileType = splitString[0];	
	}
    //see if its PDF
    if(fileType!=null && fileType=="application/pdf"){
        Stream stream = response.GetResponseStream();
        //save it
        using(FileStream fileStream = File.Create(fileFullPath)){
          // Initialize the bytes array with the stream length and then fill it with data
          byte[] bytesInStream = new byte[stream.Length];
          stream.Read(bytesInStream, 0, bytesInStream.Length);    
          // Use write method to write to the file specified above
          fileStream.Write(bytesInStream, 0, bytesInStream.Length);
        }
    }
    response.Close();
