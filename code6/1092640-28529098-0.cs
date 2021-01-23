     TableBatchOperation batchOperation = new TableBatchOperation();
    
                    foreach (var retrivedatafromlist in registrationDescriptionsList)
                    {
    
                        NotificationHubServiceBus NhsbObj = new NotificationHubServiceBus();
    
                        var tags = "";
    
                        foreach (var a in retrivedatafromlist.Tags)
                        {
                            tags = tags + a;
                        }
    
                     
    
                        NhsbObj.PartitionKey = "Sample";
                        NhsbObj.RowKey = retrivedatafromlist.RegistrationId;
                        NhsbObj.RegistrationId = retrivedatafromlist.RegistrationId;
                        NhsbObj.ExpirationDate = retrivedatafromlist.ExpirationTime.ToString();
                        NhsbObj.ETag = retrivedatafromlist.ETag;
                        NhsbObj.Tags = tags;
    
                        batchOperation.Insert(NhsbObj);
    
                    }
                    table.ExecuteBatch(batchOperation);
