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
                        for (int j = 0; j < 100000; j++)
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
                        else
                        {
                            token.ThrowIfCancellationRequested();
                        }
                        }
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
                    ae.Handle((task) =>
                        {
                            Console.WriteLine("Cancel all others child tasks  requested ");
                            return true;
                        });
                }
                
                Console.WriteLine("Children finished");
                return children.Sum(t => t.Result);
            });
            try
            {
                parent.Wait();
            }
            catch (AggregateException aex)
            {
                aex.Handle((task) =>
                {
                    Console.WriteLine("Cancel child work  done ");
                    return true;
                });              
            }
            
            Console.WriteLine("Parent finished");
            return parent.Result;
        }
    
