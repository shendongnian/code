    namespace ConsoleApplication1
    {
        public class Program
        {
            private static async Task<string> SaveAMessage(string message)
            {
                var messages = new List<string>();
                messages.Add(message);
                return await save(messages);
            }
            
            private static Task<string> save(List<string> msg)
            {
                Task<string> task = Task.Factory.StartNew<string>(() =>
                {
                    Console.WriteLine("Message " + msg[0] + " received...");
                    Console.WriteLine("Message " + msg[0] + " running...");
                    Thread.Sleep(3000);
                    return "Message " + msg[0] + " finally return.";
                });
                return task;
            }
            
            public static void Main(string[] args)
            {
                Task<string> first = SaveAMessage("Msg1");
                first.ContinueWith(x => Console.WriteLine("Print " + x.Result));
                Task<string> second = SaveAMessage("Msg2");
                second.ContinueWith(x => Console.WriteLine("Print " + x.Result));
                Console.ReadKey();
            }    
        }
    }
