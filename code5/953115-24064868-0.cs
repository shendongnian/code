    private void GetVariableFile(string remoteUri, string filename){
    string myStringWebResource = null;
    
    // Create a new WebClient instance.
    using (WebClient myWebClient = new WebClient())
    {
        myStringWebResource = remoteUri + fileName;
        // Download the Web resource and save it into the current filesystem folder.
        myWebClient.DownloadFile(myStringWebResource, fileName);
    //Do stuffs        
    }
    }
