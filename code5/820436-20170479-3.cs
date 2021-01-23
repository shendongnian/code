    public class Program
    {
        public static void Main(string[] args)
        {
            var agg = new EventAggregator();
            var test = new Test();
            agg.Subscribe<Message>(test.Handler);
            agg.Subscribe<Message>(StaticHandler);
            agg.Publish(new Message() { Data = "Start test" });
            GC.KeepAlive(test);
            
            for(int i = 0; i < 10; i++)
            {
                byte[] b = new byte[1000000]; // allocate some memory
                agg.Publish(new Message() { Data = i.ToString() });
                Console.WriteLine(GC.CollectionCount(2));
                GC.KeepAlive(b); // force the allocator to allocate b (if not in Debug).
            }
            
            GC.Collect();
            agg.Publish(new Message() { Data = "End test" });
        }
        
        private static void StaticHandler(Message m)
        {
            Console.WriteLine("Static Handler: {0}", m.Data);
        }
    }
    
    public class Test
    {
        public void Handler(Message m)
        {
            Console.WriteLine("Instance Handler: {0}", m.Data);
        }
    }
    
    public class Message
    {
        public string Data { get; set; }
    }
