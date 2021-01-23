    static void Main(string[] args)
            {
                var account = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureStorageAccount"].ConnectionString);
                var bClient = account.CreateCloudBlobClient();
                var container = bClient.GetContainerReference("test-share-container-1");
                container.CreateIfNotExists();
                
                // clear all existing policy
                ClearPolicy(container);
    
                string newPolicy = "blobsharepolicy";
                CreateSharedAccessPolicyForBlob(container, newPolicy);
                var bUri = BlobUriWithNewPolicy(container, newPolicy);
    
                Console.ReadLine();
            }
    
            static void ClearPolicy(CloudBlobContainer container)
            {
                var perms = container.GetPermissions();
                perms.SharedAccessPolicies.Clear();
                container.SetPermissions(perms);
            }       
    
            static string BlobUriWithNewPolicy(CloudBlobContainer container, string policyName)
            {
                var blob = container.GetBlockBlobReference("testfile1.txt");
                string blobContent = "Hello there !!";
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(blobContent));
                ms.Position = 0;
                using (ms)
                {
                    blob.UploadFromStream(ms);
                }
                
                return blob.Uri + blob.GetSharedAccessSignature(null, policyName);
            }
            
            static void CreateSharedAccessPolicyForBlob(CloudBlobContainer container, string policyName)
            {
                SharedAccessBlobPolicy sharedPolicy = new SharedAccessBlobPolicy()
                {
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                    Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Read
                };
                var permissions = container.GetPermissions();            
                permissions.SharedAccessPolicies.Add(policyName, sharedPolicy);
                container.SetPermissions(permissions);
            }
    
    
    <connectionStrings>
        <add name="AzureStorageAccount" connectionString="DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]" />
      </connectionStrings>
