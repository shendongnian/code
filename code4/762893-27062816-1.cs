        public static void Main(string[] args)
        {
            var operationWithTimeout = new OperationWithTimeout();
            TimeSpan timeout = TimeSpan.FromMilliseconds(10000);
            Func<CancellationToken, object> operation = token =>
            {
                Thread.Sleep(9000); // 12000
                if (token.IsCancellationRequested)
                {
                    Console.Write("Operation was cancelled.");
                    return null;
                }
                return 123456;
            };
            try
            {
                var t = operationWithTimeout.Execute(operation, timeout);
                var result = t.Result;
                Console.WriteLine("Operation returned '" + result + "'");
            }
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
            }
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
