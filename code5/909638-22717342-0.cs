      static int GetSum()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var parent = Task<int>.Factory.StartNew(() =>
            {
                var children = new Task<int>[100];
                for (var i = 0; i < children.Length; i++)
                {
                    var index = i;
                    children[index] = Task<int>.Factory.StartNew(() =>
                    {
                        if (!token.IsCancellationRequested)
                        {
    
    
                            var randomNumber = new Random().Next(5);
                            if (randomNumber == 0)
                            {
                                throw new Exception();
                            }
    
                            return randomNumber;
                        }
                        token.ThrowIfCancellationRequested();
                        return 0;
                    }
                    , token);
                }
                try
                {
                    Task.WaitAny(children);
                }
                catch (AggregateException ae)
                {
    
                    tokenSource.Cancel();
                    Console.WriteLine("Cancel all others child tasks  requested ");
                }
                
                Console.WriteLine("Children finished");
                return children.Sum(t => t.Result);
            });
    
            try
            {
                parent.Wait();
            }
            catch (AggregateException ex)
            {
                
                throw;
            }
            
            Console.WriteLine("Parent finished");
            return parent.Result;
        }
    
