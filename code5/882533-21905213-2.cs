    // Add a subscription to a topic
    var subscription = dbContect.Subscriptions.Find(2);
    var topic = dbContext.Topics.Find(1);
    
    // Recommend checking here, but omitted for example
    
    // Make the association
    topic.Subscriptions.Add(subscription);
    
    // Update
    dbContext.SaveChanges();
