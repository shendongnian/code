        public void AddCompanyStorage(string subDomain)
            {
                //get the storage account.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    System.Configuration.ConfigurationManager.AppSettings["StorageConnectionString"].ToString());
        
                //blob client now
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();            
        
                //the container for this is companystyles
               CloudBlobContainer container = blobClient.GetContainerReference(subDomain);
                
                //Create a new container, if it does not exist
               container.CreateIfNotExist();
            } 
