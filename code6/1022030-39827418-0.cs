                // ******
        static string bucketForImage = ConfigurationManager.AppSettings["testStorageName"];
        static string projectName = ConfigurationManager.AppSettings["GCPProjectName"];
                string gcpPath = Path.Combine(Server.MapPath("~/Images/Gallery/"), uniqueGcpName + ext);
                var clientSecrets = new ClientSecrets();
                clientSecrets.ClientId = ConfigurationManager.AppSettings["GCPClientID"];
                clientSecrets.ClientSecret = ConfigurationManager.AppSettings["GCPClientSc"];
                var scopes = new[] { @"https://www.googleapis.com/auth/devstorage.full_control" };
                var cts = new CancellationTokenSource();
                var userCredential = await GoogleWebAuthorizationBroker.AuthorizeAsync(clientSecrets, scopes, ConfigurationManager.AppSettings["GCPAccountEmail"], cts.Token);
                var service = new Google.Apis.Storage.v1.StorageService();
                var bucketToUpload = bucketForImage;
                var newObject = new Google.Apis.Storage.v1.Data.Object()
                {
                    Bucket = bucketToUpload,
                    Name = bkFileName
                };
                FileStream fileStream = null;
                try
                {
                    fileStream = new FileStream(gcpPath, FileMode.Open);
                    var uploadRequest = new Google.Apis.Storage.v1.ObjectsResource.InsertMediaUpload(service, newObject,
                    bucketToUpload, fileStream, "image/"+ ext);
                    uploadRequest.OauthToken = userCredential.Token.AccessToken;
                    await uploadRequest.UploadAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (fileStream != null)
                    {
                        fileStream.Dispose();
                    }
                }
                // ******
