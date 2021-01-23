     [HttpPost]
            public ActionResult Index(Doctor doct, HttpPostedFileBase photo)
            {
               
                try
                {
                    if (photo != null && photo.ContentLength > 0)
                    {
                        // extract only the fielname
                        var fileName = Path.GetFileName(photo.FileName);
                        doct.Image = fileName.ToString();
                       
                        CloudStorageAccount cloudStorageAccount = DoctorController.GetConnectionString();
                        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("images");
    
                        
                        string imageName = Guid.NewGuid().ToString() + "-" +Path.GetExtension(photo.FileName); 
    
                        CloudBlockBlob BlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                        
                        BlockBlob.Properties.ContentType = photo.ContentType;
                        BlockBlob.UploadFromStreamAsync(photo.InputStream);
                        string imageFullPath = BlockBlob.Uri.ToString();
    
                        var memoryStream = new MemoryStream();
    
                       
                        photo.InputStream.CopyTo(memoryStream);
                        memoryStream.ToArray();
    
                     
    
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        using (var fs = photo.InputStream)
                        {
                            BlockBlob.UploadFromStreamAsync(memoryStream);
                        }
                       
                    }
                }
                catch (Exception ex)
                {
    
                }
    
                   
                return View();
            }
