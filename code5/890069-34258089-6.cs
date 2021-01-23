        // Retrieve the storage account from the connection string.
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
        // Create the table client.
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        // Create the CloudTable object that represents the "people" table.
        CloudTable table = tableClient.GetTableReference("people");
        // Create the batch operation.
        TableBatchOperation batchOperation = new TableBatchOperation();
        // Create a customer entity and add it to the table.
        CustomerEntity customer1 = new CustomerEntity("Smith", "Jeff");
        customer1.Email = "Jeff@contoso.com";
        customer1.PhoneNumber = "425-555-0104";
        // Create another customer entity and add it to the table.
        CustomerEntity customer2 = new CustomerEntity("Smith", "Ben");
        customer2.Email = "Ben@contoso.com";
        customer2.PhoneNumber = "425-555-0102";
        // Add both customer entities to the batch insert operation.
        batchOperation.Insert(customer1);
        batchOperation.Insert(customer2);
        // Execute the batch operation.
        await table.ExecuteBatchAsync(batchOperation);
