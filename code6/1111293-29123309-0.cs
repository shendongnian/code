    var getBlob = blobContainer.GetBlobReferenceFromServer(fileUploadLink.Name);
    
    if(getBlob != null)
    {
      MemoryStream memoryStream = new MemoryStream();
      getBlob.DownloadToStream(memoryStream);
      memoryStream.Seek(0,SeekOrigin.Begin); // Reset stream back to beginning
      emailMessage.AddAttachment(memoryStream, fileUploadLink.Name);
    }
    emailTransport.Deliver(emailMessage);
