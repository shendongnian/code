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
            PublishDataEventArgs e = new PublishDataEventArgs();
            e.Message = "Hello from Subscriber";
            Publisher p = new Publisher();
            List<Subscriber> subs = GetSubscribers();
            p.PublishData += new EventHandler<PublishDataEventArgs>(subs[0].PrintMessage);
            p.PublishData += new EventHandler<PublishDataEventArgs>(subs[1].PrintMessage);
            p.PublishData += new EventHandler<PublishDataEventArgs>(subs[2].PrintMessage);
            p.PublishData += new EventHandler<PublishDataEventArgs>(subs[3].PrintMessage);
            p.OnPublishData(e);
            Console.ReadKey();
        }
       
    }
    class Publisher
    {  
        public void OnPublishData(PublishDataEventArgs p)
        {
            EventHandler<PublishDataEventArgs> _PublishData = PublishData;
            if (_PublishData != null)
                _PublishData(this, p);
        }
        public event EventHandler<PublishDataEventArgs> PublishData;
    }
    class PublishDataEventArgs:EventArgs
    {
        public string Message{get;set;}
    }
    class Subscriber
    {
        public string IP { get; set; }
        public string Port { get; set; }
        public void PrintMessage(object sender,PublishDataEventArgs e)
        {
            Console.WriteLine("Data has arrived for IP " + IP + " Port " + Port + " message " + e.Message );
        }
    }
