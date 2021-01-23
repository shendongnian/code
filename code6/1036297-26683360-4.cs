    public class QueueStuff{
    private static IAmazonSQS SQS; 
    
    //Get only one of these
    public QueueStuff(){
       SQS = AWSClientFactory.CreateAmazonSQSClient(RegionEndpoint.EUWest1);
    }
    //...use SQS elsewhere...
