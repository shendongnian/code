    //Scopes for use with the Google Drive API
    string[] scopes = new string[] { DriveService.Scope.Drive,
                                     DriveService.Scope.DriveFile};
    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
    UserCredential credential = 
                GoogleWebAuthorizationBroker
                              .AuthorizeAsync(new ClientSecrets { ClientId = CLIENT_ID
                                                                , ClientSecret = CLIENT_SECRET }
                                              ,scopes
                                              ,Environment.UserName
                                              ,CancellationToken.None
                                              ,new FileDataStore("Daimto.GoogleDrive.Auth.Store")
                                              ).Result;
    DriveService service = new DriveService(new BaseClientService.Initializer()
     {
     HttpClientInitializer = credential,
     ApplicationName = "Drive API Sample",
     });
    
     public static File uploadFile(DriveService _service, string _uploadFile, string _parent) {
                
                if (System.IO.File.Exists(_uploadFile))
                {
                    File body = new File();
                    body.Title = System.IO.Path.GetFileName(_uploadFile);
                    body.Description = "File uploaded by Diamto Drive Sample";
                    body.MimeType = GetMimeType(_uploadFile);
                    body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
    
                    // File's content.
                    byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                    try
                    {
                        FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
                        request.Upload();
                        return request.ResponseBody;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        return null;
                    }
                }
                else {
                    Console.WriteLine("File does not exist: " + _uploadFile);
                    return null;
                }           
            
            }
