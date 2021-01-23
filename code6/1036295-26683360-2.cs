    public class QueueStuff{
    private static IAmazonSQS SQS; 
    
    //Get only one of these
    public QueueStuff(){
       SQS = AWSClientFactory.CreateAmazonSQSClient(RegionEndpoint.EUWest1);
    }
    public static string sendSqs(string data)
    {
      SendMessageRequest sendMessageRequest = new SendMessageRequest();
      CreateQueueRequest sqsRequest = new CreateQueueRequest();
      sqsRequest.QueueName = "mySqsQueue";
      CreateQueueResponse createQueueResponse = sqs.CreateQueue(sqsRequest);
      sendMessageRequest.QueueUrl = createQueueResponse.QueueUrl;
      sendMessageRequest.MessageBody = data;
      SendMessageResponse sendMessageresponse = SQS.SendMessage(sendMessageRequest);
      return sendMessageresponse.MessageId;
    }
