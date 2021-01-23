            var t1 = Task.Factory.StartNew(() => Console.WriteLine("Task 1"));
            var t2 = Task.Factory.StartNew(() => Console.WriteLine("Task 2"));
            var t3 = Task.Factory.StartNew(() => { throw new InvalidOperationException(); });
            var t4 = Task.Factory.StartNew(() => Console.WriteLine("Task 4"));
            Task.Factory.ContinueWhenAll(new[] { t1, t2, t3, t4 }, tasks =>
                {
                    foreach (var t in tasks)
                    {
                        if (t.Status == TaskStatus.Faulted)
                        {
                            // this will run for t3
                            Console.WriteLine("This task has been faulted.");
                        }
                    }
                });
