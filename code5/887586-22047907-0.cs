    // Connect to the a queue on the local computer.
    MessageQueue myQueue = new MessageQueue(".\\myQueue");
    
    // Set the formatter to indicate body contains an Order.
    myQueue.Formatter = new XmlMessageFormatter(new Type[] {typeof(MyProject.Order)});
    
    // Receive and format the message. 
    Message myMessage =	myQueue.Receive(); 
    Order myOrder = (Order)myMessage.Body;
