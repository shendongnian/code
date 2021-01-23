    IAmazonSQS sqs = AWSClientFactory.CreateAmazonSQSClient();
    ReceiveMessageResponse receiveMessage = new ReceiveMessageResponse();
    ReceiveMessageRequest request = new ReceiveMessageRequest();
    
    //Specify attribute list
    List<string> AttributesList = new List<string>();
    AttributesList.Add("MESSAGEPRIORITY");
    
    //Assign list and QueueURL to request
    request.MessageAttributeNames = AttributesList;
    request.QueueUrl = "myURL";
    
    //Receive the message...
    receiveMessage = sqs.ReceiveMessage(request);
    //Body...
    string messageBody = receiveMessage.Messages[0].Body;
    //...and attributes
    Dictionary<string, MessageAttributeValue> messageAttributes = receiveMessage.Messages[0].MessageAttributes;
