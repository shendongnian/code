    using System;
    using System.Text;
    using BookSleeve;
    
    static class Program
    {
        static void Main()
        {
            // IMPORTANT: the "pub" and "sub" can be on entirely separate machines,
            // as long as they are talking to the same server. They are only shown
            // together here for convenience
            using (var sub = new RedisSubscriberConnection("localhost"))
            using (var pub = new RedisConnection("localhost"))
            {
                sub.Open();
                pub.Open();
    
                sub.Subscribe("busytime", (queue,payload) =>
                {
                    // you don't actually need the payload, probably 
                    var received = Encoding.UTF8.GetString(payload);
                    Console.WriteLine("Work to do! Look busy!: " + received);
                });
    
                string line;
                Console.WriteLine("Enter messages to send, or q to quit");
                while((line = Console.ReadLine()) != null && line != "q")
                {
                    pub.Publish("busytime", line);
                }
            }
        }
    }
