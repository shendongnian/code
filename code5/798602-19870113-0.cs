    AmazonSQSClient sq = new AmazonSQSClient("xx", "yy");
    while (true)
    {
        ReceiveMessageRequest rmr = new ReceiveMessageRequest();
        rmr.QueueUrl = url;
        rmr.MaxNumberOfMessages = 10;
        ReceiveMessageResponse response= sq.ReceiveMessage(rmr);
        foreach (Message message in response.ReceiveMessageResult.Message)
        {
            MessageBox.Show(message.ReceiptHandle + ": " + message.Body);
        }
    }
