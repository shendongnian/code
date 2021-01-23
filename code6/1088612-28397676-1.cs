    public class Telegram<T>
    {
       public Telegram(double time, int otherSender, int otherReceiver,
                Message otherMessage, T info = null)
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
       public T ExtraInfo {get; private set;}
    }
