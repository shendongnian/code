        // By default when connecting to the queue we will look at the appSettings for they key "Microsoft.ServiceBus.ConnectionString"
        //
        //  <appSettings>
        //    <add key="Microsoft.ServiceBus.ConnectionString" value="Endpoint=sb://XXXXXXXXXX.servicebus.windows.net;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=XXXXXXXXXXXXXXXXXXXXXXXXXXX" />
        //  </appSettings>
        //
        public TachyonQueueClient(String queueName, String appSettingKey = "Microsoft.ServiceBus.ConnectionString")
        {
            name = queueName;
            string connectionString = CloudConfigurationManager.GetSetting(appSettingKey);
            namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
            if (!namespaceManager.QueueExists(queueName))
            {
                namespaceManager.CreateQueue(queueName);
            }
            // Initialize the connection to Service Bus Queue
            client = QueueClient.CreateFromConnectionString(connectionString, queueName);
        }
