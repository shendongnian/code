    public string GetLocalPath(this Microsoft.Office.Interop.PowerPoint.Presentation presentation)
    {
        WebClient client = new WebClient();
        string localPath = client.DownloadString(presentation.Path + "LocalDrivePath.txt");
        return localPath;
    }
