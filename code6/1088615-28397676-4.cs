    public class Telegram
    {
       public Telegram(double time, int otherSender, int otherReceiver,
                Message otherMessage, object info = null)
       {
            DispatchTime = time;
            Sender = otherSender;
            Receiver = otherReceiver;
            MessageToSend = otherMessage;
            ExtraInfo = info;
       }
       public int Reciever {get; private set;}
       public Message MessageToSend {get; private set;}
       public double DispatchTime {get; set;}
       public object ExtraInfo {get; private set;}
    }
