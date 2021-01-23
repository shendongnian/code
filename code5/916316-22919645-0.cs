    public bool WriteFileData(Stream data, DSFile file, DSUser user)
            {      
                var parent = new Parent();
                var folders = GetUserFolders(user, false);
                SDFolder parentFolder = folders.Where(f => f.FullPath == file.VirtualPath).FirstOrDefault();
                parent.Id = parentFolder.DepositoryFolderId;
    
                var addFileRequest = new AddFileRequest();
                addFileRequest.Parents.Add(parent);
                addFileRequest.Title = (file.FileName.ToLower().Contains(".ext") == false) ? file.FileName + ".ext" : file.FileName;
                addFileRequest.ModifiedDate = ServiceUtil.ToISO8601(DateTime.Now);
                addFileRequest.MimeType = "application/octet-stream";
                addFileRequest.WritersCanShare = false;
                addFileRequest.Description = file.Description;
                addFileRequest.Labels = new FileLabels();
    
                string metadata = Microsoft.Http.HttpContentExtensions.CreateJsonDataContract<AddFileRequest>(addFileRequest).ReadAsString();
    
                var content = new System.Net.Http.MultipartFormDataContent("ABC123");
                content.Add(new System.Net.Http.StringContent(metadata, System.Text.Encoding.UTF8, "application/json"));
                content.Add(new System.Net.Http.StreamContent(data));
    
                try
                {            
                    var client = new System.Net.Http.HttpClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", credential.AccessToken);
                    var response = client.PostAsync("https://www.googleapis.com/upload/drive/v2/files?uploadType=multipart", content).Result;
    
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
