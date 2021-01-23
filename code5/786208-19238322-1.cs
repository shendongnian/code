    public class MySender
    {
       public void SendMessage()
       {
           DumbAggregator.BroadCast("Hello There!");
       }
    }
    public class MySubscriber
    {
       public MySubscriber()
       {
           DumbAggregator.OnMessageTransmitted += OnMessageReceived;
       }
    
       private void OnMessageReceived(string message)
       {
          MessageBox.Show("I Received a Message! - " + message);
       }
    }
