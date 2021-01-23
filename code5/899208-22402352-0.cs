    int messageCount = client.GetMessageCount();//client is POP3Client instance
    List<Message> _allMessages = new List<Message>(messageCount);
     
    for (int i = messageCount; i > 0; i--)    
         _allMessages .Add(client.GetMessage(i));
