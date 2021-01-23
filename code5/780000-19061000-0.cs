    HttpWebRequest gameFile = (HttpWebRequest)WebRequest.Create(ONLINEFILE_URL);
    HttpWebResponse gameFileResponse = (HttpWebResponse)gameFile.GetResponse();
    
    DateTime localFileModifiedTime = File.GetLastWriteTime(LOCALFILE_PATH);
    DateTime onlineFileModifiedTime = gameFileResponse.LastModified;
    
    if (localFileModifiedTime >= onlineFileModifiedTime) {
        //Play Game
    } else {
        //Download new Update
    }
