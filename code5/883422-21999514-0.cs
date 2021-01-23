    using (var azure = new ServiceBusManagementClient(...))
    {
       var allYourServiceNamespaces = await azure.Namespaces.ListAsync();
       var topic = azure.Topics.Get(allYourServiceNamespaces.First().Name,"topicname").Topic;
       
    }
