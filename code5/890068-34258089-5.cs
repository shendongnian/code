        public class CustomerEntity : TableEntity
        {
            public CustomerEntity(string lastName, string firstName)
            {
                this.PartitionKey = lastName;
                this.RowKey = firstName;
            }
            public CustomerEntity() { }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
        ...
        //The script:
        // Retrieve the storage account from the connection string.
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
        // Create the table client.
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        // Create the CloudTable object that represents the "people" table.
        CloudTable table = tableClient.GetTableReference("people");
        // Create a new customer entity.
        CustomerEntity customer1 = new CustomerEntity("Harp", "Walter");
        customer1.Email = "Walter@contoso.com";
        customer1.PhoneNumber = "425-555-0101";
        // Create the TableOperation object that inserts the customer entity.
        TableOperation insertOperation = TableOperation.Insert(customer1);
        // Execute the insert operation.
        await table.ExecuteAsync(insertOperation);
