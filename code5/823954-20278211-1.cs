    //gets contents at requested path
    var metaData = _client.GetMetaData("/Public/DropboxManagement/Logs");
    //without knowing how this API works, Path may be a full path and therefore need to check for "/Public/DropboxManagement/Logs" + folder
    if (metaData.Contents.Any(c => c.Is_Dir && md.Path == folder)
    {
         //folder exists
    }
