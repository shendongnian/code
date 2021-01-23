            bool complete = false;
            // Start tasks
            Task task_1 = factory.StartNew(() =>
            {
                Console.WriteLine("1");
                Console.WriteLine("2");
                if (complete)
                {
                    Console.WriteLine("3");
                }
                complete = true;
            });
            task_1.Wait();
