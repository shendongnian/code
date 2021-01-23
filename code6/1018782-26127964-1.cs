     public class ProcessMessage
     {
        Client client = new Client();
        DisplayMessage msg = new DisplayMessage();
        client.MessageArrived += new MessageHandler(msg.DisplayMessage);
        client.CheckForMessage(); 
     }
