    string QueueName = ".\\Private$\\logline";
    MessageQueue myQueue = new MessageQueue(QueueName);
    myQueue.Formatter = new BinaryMessageFormatter();
    System.Messaging.Message myMessage = myQueue.Receive(); 
    string myData = (string)myMessage.Body;
