     public class Program
     {
        static List<Subscriber> GetSubscribers()
        {
            return
                new List<Subscriber>
                {
                    new Subscriber{IP ="1.2.3.4",Port="1521"},
                    new Subscriber{IP="2.2.2.2",Port="8080"},
                    new Subscriber{IP="4.4.4.4",Port="1250"},
                    new Subscriber{IP="6.6.6.6",Port="4123"}
                };
        }
        static void Main(string[] args)
        {
            Publisher p = new Publisher();
            List<Subscriber> subs = GetSubscribers();
            p.PublishEvent += new Publisher.PublishData(subs[0].PrintMessage);
            p.PublishEvent += new Publisher.PublishData(subs[1].PrintMessage);
            p.PublishEvent += new Publisher.PublishData(subs[2].PrintMessage);
            p.PublishEvent += new Publisher.PublishData(subs[3].PrintMessage);
            p.OnPublishData();
            Console.ReadKey();
        }
       
    }
    class Publisher
    {
        
        public delegate void PublishData();
        public event PublishData PublishEvent;
        public void OnPublishData()
        {           
            if (PublishEvent != null)
                PublishEvent();
        }
    }
    class Subscriber
    {
        public string IP { get; set; }
        public string Port { get; set; }
        public void PrintMessage()
        {
            Console.WriteLine("Data has arrived for IP " + IP + " Port " + Port);
        }
    }
