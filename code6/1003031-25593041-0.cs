        private void CreateThreadsToAccess()
        {
            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i += 1)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                //  here you get four different instances
                    bool success = Dll.Instance.DoSomething();
                    Console.WriteLine(success);
                });
            }
            Task.WaitAll(tasks);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
