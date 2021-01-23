        storageAccount = new CloudStorageAccount(new StorageCredentials("accountname", "accountkey"), false);
        var container = storageAccount.CreateCloudBlobClient().GetContainerReference("containername");
        //Get the container permission
        var permissions = container.GetPermissions();
        Console.WriteLine("Container's ACL is: " + permissions.PublicAccess);
        //Set the container permission to Blob
        container.SetPermissions(new BlobContainerPermissions()
        {
            PublicAccess = BlobContainerPublicAccessType.Blob,
        });
