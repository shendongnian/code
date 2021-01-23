        class Program
        {
            static void Main(string[] args)
            {
               var count = 0;
               while (true)
               {
                   Console.WriteLine("Hello from XYZ "+count);
                   count++;
                   Thread.Sleep(1000);
               }
           }
        }
