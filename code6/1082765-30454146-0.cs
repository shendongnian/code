    var NewDirRequest = DService.Files.Insert(GoogleDir);
    var NewDir = NewDirRequest.Execute();
    GoogleFolderID = NewDir.Id;
    var NewPermissionsRequest = DService.Permissions.Insert(new Permission()
    {
        Kind = "drive#permission",
        Value = emailAddress,
        Role = "writer",
        Type = "user"
    }, GoogleFolderID);
    DService.Permissions.Insert(new Permission()
    {
        Kind = "drive#permission",
        Value = "mydomain.com",
        Role = "reader",
        Type = "domain"
    }, GoogleFolderID);
    NewPermissionsRequest.Execute();
