    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var sub = context.Socket(SocketType.SUB);
                sub.Connect("tcp://localhost:2550");
                sub.Subscribe(string.Empty, Encoding.UTF8);
                while (true)
                {
                    var data = sub.Recv(Encoding.UTF8);
                    Console.WriteLine(data);
                }
            }
        }
    } 
