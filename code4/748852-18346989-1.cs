    // receive a message
    ReceiveMessageRequest receiveMessageRequest = new ReceiveMessageRequest();
    receiveMessageRequest.QueueUrl = myQueueUrl;
    ReceiveMessageResponse receiveMessageResponse = sqs.
       ReceiveMessage(receiveMessageRequest);
    if (receiveMessageResponse.IsSetReceiveMessageResult())
    {
        Console.WriteLine("Printing received message.\n");
        ReceiveMessageResult receiveMessageResult = receiveMessageResponse.
            ReceiveMessageResult;
        foreach (Message message in receiveMessageResult.Message)
        {
            // process the message (see below)
        }
    }
