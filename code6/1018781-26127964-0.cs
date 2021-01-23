    public delegate void MessageHandler(string message);
    
    public class Client
    {
       public event MessageHandler MessageArrived;
       
       public void CheckForMessage() //logic to check if message is received
       {
         //other code to check for message
          if(MessageArrived != null)
             MessageArrived("message received");
       }
    }
    public class DisplayMessage
    {
      public void DisplayMessage(string message)
      {
        Console.WriteLine("Message: {0}", message);
      }
    }
