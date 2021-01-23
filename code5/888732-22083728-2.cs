    var myTopic = new TopicDescription(topicName)
    {
        EnableFilteringMessagesBeforePublishing = true
    };
    namespaceManager.CreateTopic(myTopic);
