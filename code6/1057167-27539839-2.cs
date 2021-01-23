    public string GetLocalPath(this Microsoft.Office.Interop.PowerPoint.Presentation presentation)
    {
        WebClient client = new WebClient();
        string localPath = client.DownloadString(presentation.Path + "LocalDrivePath.txt");
        //Some good old protective programming to quickly identify the problem if the file doesn't exist
        if (!string.IsNullOrEmpty(localPath)) throw new Exception("Issue: LocalDrivePath.txt not found in " + presentation.Path + Environment.Newline + "Please add the file for this Office Documents' sync'd (offline) local folder to be identified.");
        return localPath;
    }
