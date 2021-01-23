    var descriptions = Request.Content.ReadAsMultipartAsync(streamProvider)
                              .ContinueWith<IEnumerable<FileDescription>>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    }
                    var fileInfo = streamProvider.FileData.Select(i =>
                    {
                        var info = new FileInfo(i.LocalFileName);
                        return new FileDescription(){
                            AssociatedSchool = 1;
                            FileName = info.Name;
                            LocalFileName = i.LocalFileName;
                            FileSize = info.Length / 1024;
                            IsFileValid = true;
                            NoOfRecords = 1;
                            UploadedBy = 1;
                        }
                    });
                    return fileInfo;
                }).Result;
    var temp = descriptions.First();//Possibly you need FirstOrDefault
