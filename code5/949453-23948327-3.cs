    public abstract class MobilePhone
    {
        public virtual void Calling()
        {
            Console.Write("Calling");
        }
        public abstract void SendSMS();
    }
    public class Nokia1400 : MobilePhone
    {
        public override void SendSMS()
        {
            Console.WriteLine("Sending SMS from Nokia 1400.");
        }
    }
    public class Nokia2700 : MobilePhone
    {
        public void FMRadio()
        {
            Console.WriteLine("FM Radio");
        }
        public void MP3()
        {
            Console.Write("MP3");
        }
        public void Camera()
        {
            Console.WriteLine("Camera");
        }
        public override void SendSMS()
        {
            Console.WriteLine("Sending SMS from Nokia 2700.");
        }
    }
