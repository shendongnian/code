            static void Main(string[] args)
            {
                Task task1 = new Task(() => Console.WriteLine("1"));
                Task task2 = new Task(() => Console.WriteLine("2"));
                Task task3 = new Task(() => Console.WriteLine("3"));
                task1.ContinueWith(previous => task2.Start());
                task2.ContinueWith(previous => task3.Start());
                task1.Start();
                task2.Wait();
                Console.WriteLine("Done.");
            }
