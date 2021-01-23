    try
    {
        topicClient.Send(message);
        Console.WriteLine(string.Format("Message sent: Id = {0}, Body = {1}", message.MessageId, message.GetBody<string>()));
    }
    catch (NoMatchingSubscriptionException ex)
    {
        string messageBody = message.GetBody<string>();                        
        BrokeredMessage msg = new BrokeredMessage(messageBody);
        msg.Properties.Add("Filter", "NoMatch");
        foreach (var prop in message.Properties)
        {
            msg.Properties.Add(prop.Key, prop.Value);
        }
        topicClient.Send(msg);
        Console.WriteLine("\n NoMatchingSubscriptionException - message resent to NoMatchingSubscription");
        Console.WriteLine(string.Format("Message sent: Id = {0}, Body = {1}", msg.MessageId, msg.GetBody<string>()));
    }
