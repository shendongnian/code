    static void Main(string[] args)
        {
            IntervalMessage("this is a test");
            Console.ReadKey();
        }
            public static void IntervalMessage(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if (i == message.Length - 1)
                {
                    Console.Write(message[i]);
                    System.Threading.Thread.Sleep(120);
                }
                else
                {
                    Console.Write(message[i]);
                    System.Threading.Thread.Sleep(110);
                }
            }
            Console.ResetColor();
        }
