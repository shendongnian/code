            try
            {
                var t1 = Task.Delay(1000);
                var t2 = t1.ContinueWith(t =>
                {
                    Console.WriteLine("task 2");
                    throw new Exception("task 2 error");
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
                var t3 = t2.ContinueWith(_ =>
                {
                    Console.WriteLine("task 3");
                    return Task.Delay(1000);
                }, TaskContinuationOptions.OnlyOnRanToCompletion).Unwrap();
                // The key is to await for all tasks rather than just
                // the first or last task.
                await Task.WhenAll(t1, t2, t3);
            }
            catch (AggregateException aex)
            {
                aex.Flatten().Handle(ex =>
                    {
                        // handle your exceptions here
                        Console.WriteLine(ex.Message);
                        return true;
                    });
            }
