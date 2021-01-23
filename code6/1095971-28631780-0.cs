            // Your Storage credentials
            var credentials = new StorageCredentials("account", "key");
            
            var storageAccount = new CloudStorageAccount(credentials, true);
            // Create a new client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            // Retrieve a reference to a queue
            CloudQueue queue = queueClient.GetQueueReference("myqueue");
            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();
            // Send 10 messages to the queue
            for (int i = 0; i < 10; i++)
            {
                // Create a message and add it to the queue.
                CloudQueueMessage message = new CloudQueueMessage(string.Format("Hello, World {0}", i));
                queue.AddMessage(message);
            }
            // Read next 20 messages
            foreach (CloudQueueMessage message in queue.GetMessages(20, TimeSpan.FromMinutes(5)))
            {
                // Reading content from message
                Console.WriteLine(message.AsString);
                // Process all messages in less than 5 minutes, deleting each message after processing.
                queue.DeleteMessage(message);
            }
