    static void Main(string[] args)
                {
                    Timer tmr = new Timer(S, null, 0, 5000);
                    Console.Read();
                }
                static void S(object obj)
                {
                    Console.WriteLine("1");
                }
