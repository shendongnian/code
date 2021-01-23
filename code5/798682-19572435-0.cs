                try
                {
                    Task.WaitAll(task1, task2, task3);
                }
                catch (AggregateException ex)
                {
                    foreach (Exception exx in ex.Flatten().InnerExceptions)
                        Console.WriteLine(exx.Message);
                }
