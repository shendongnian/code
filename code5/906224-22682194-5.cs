    using System;
    using GalaSoft.MvvmLight.Messaging;
    
    class Program
    {
        static void Main(string[] args)
        {
            Receiver r1 = new Receiver("r1");
            Receiver r2 = new Receiver("r2");
            var recipient = new object();
    
            Messenger.Default.Register<object>(recipient, r1).ShowMessage;
            Messenger.Default.Register<object>(recipient, r2).ShowMessage;
    
            GC.Collect();
            Messenger.Default.Send(recipient, null);
            // Uncomment one of these to see the relevant message...
            // GC.KeepAlive(r1);
            // GC.KeepAlive(r2);
        }
    }
    
    class Receiver
    {
        private string name;
    
        public Receiver(string name)
        {
            this.name = name;
        }
    
        public void ShowMessage(object message)
        {
            Console.WriteLine("message received by {0}", name);
        }
    }
