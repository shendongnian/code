    public static string sendSqs(string data)
    {
      SendMessageRequest sendMessageRequest = new SendMessageRequest();
      CreateQueueRequest sqsRequest = new CreateQueueRequest();
      sqsRequest.QueueName = "mySqsQueue";
      CreateQueueResponse createQueueResponse = sqs.CreateQueue(sqsRequest);
      sendMessageRequest.QueueUrl = createQueueResponse.QueueUrl;
      sendMessageRequest.MessageBody = data;
      try{
          SendMessageResponse sendMessageresponse = SQS.SendMessage(sendMessageRequest);
      catch(InvalidMessageContents ex){ //Catch or bubble the exception up.
        //I can't do anything about this so toss the message...
        LOGGER.log("Invalid data in request: "+data, ex);
        return null;
      } catch(Throttling ex){ //I can do something about this!
        //Exponential backoff...
      }
      return sendMessageresponse.MessageId;
    }
