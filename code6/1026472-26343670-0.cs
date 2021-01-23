     Task task1 = Task.Factory.StartNew(() =>
                    {
                        for (int i = 0; i < 10000; i++)
                        {
                            Console.WriteLine( "task1" +i);
                        }
                    });
                Task task2 = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        Console.WriteLine("task2" + i);
                    }
                });
                Task.WaitAll(task1, task2); 
                Console.WriteLine("hi I'm Here "); // hi  im here will not printed until the others 2 tasks has finished so beaware of this on UI 
                Console.ReadLine(); 
