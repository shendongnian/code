        public CustomerManager()
        {
            //set up automapper and IoC
            Initializer.Initialize();
            Publisher = IoCContainer.GetContainer().Resolve<IPublisher>("CustomerManager");
            Publisher.Subscribe("AllMessages");
            var client =
                SubscriptionClient.CreateFromConnectionString(CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString"), "customertopic", "AllMessages", ReceiveMode.PeekLock);
            client.OnMessage(m =>
            {
                Console.WriteLine("Message Received.");
                HandleMessage(m);
            });
        }
