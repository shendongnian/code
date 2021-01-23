            static void Main(string[] args)
            {
                Task task1 = new Task(() => Console.WriteLine("1"));
                Task task2 = new Task(() => Console.WriteLine("2"));
                Task task3 = new Task(() => Console.WriteLine("3"));
                Task task4 = new Task(() => Console.WriteLine("4"));
                Task task5 = new Task(() => Console.WriteLine("5"));
                task1.ContinueWith(previous => task2.Start());
                task1.ContinueWith(previous => task3.Start());
                task1.ContinueWith(previous => task4.Start());
                task1.ContinueWith(previous => task5.Start());
                task1.Start();
                task5.Wait(); // N.B. This does not guarantee that all tasks finish, only task5
                Console.WriteLine("Done.");
            }
