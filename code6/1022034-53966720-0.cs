        private string UploadFile(string localPath, string objectName = null)
            {
                string projectId = ((Google.Apis.Auth.OAuth2.ServiceAccountCredential)googleCredential.UnderlyingCredential).ProjectId;
    
                try
                {
                    // Creates the new bucket.
                    var objResult = storageClient.CreateBucket(projectId, bucketName);
                    if (!string.IsNullOrEmpty(objResult.Id))
                    {
                        // Upload file to google cloud server
                        using (var f = File.OpenRead(localPath))
                        {
                            objectName = objectName ?? Path.GetFileName(localPath);
                            var objFileUploadStatus1 = storageClient.UploadObject(bucketName, objectName, null, f);
                        }
                    }
                }
                catch (Google.GoogleApiException ex)
                {
                    // Error code =409, means bucket already created/exist then upload file in the bucket
                    if (ex.Error.Code == 409)
                    {
                        // Upload file to google cloud server
                        using (var f = File.OpenRead(localPath))
                        {
                            objectName = objectName ?? Path.GetFileName(localPath);
                            var objFileUploadStatus2 = storageClient.UploadObject(bucketName, objectName, null, f);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return objectName;
            }
    
     4. To set the credentials
    
            private bool SetStorageCredentials()
            {
                bool status = true;
                try
                {
                    if (File.Exists(credential_path))
                    {
                        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);
                        using (Stream objStream = new FileStream(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"), FileMode.Open, FileAccess.Read))
                            googleCredential = GoogleCredential.FromStream(objStream);
                        // Instantiates a client.
                        storageClient = StorageClient.Create();
                        channel = new Grpc.Core.Channel(SpeechClient.DefaultEndpoint.Host, googleCredential.ToChannelCredentials());
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("File " + Path.GetFileName(credential_path) + " does not exist. Please provide the correct path.");
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            status = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    status = false;
                }
                return status;
            }
