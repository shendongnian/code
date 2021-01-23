    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace OrderScanner.Models
    {
        class Debouncer
        {
            private List<CancellationTokenSource> StepperCancelTokens = new List<CancellationTokenSource>();
            private int MillisecondsToWait;
            private readonly object _lockThis = new object(); // Use a locking object to prevent the debouncer to trigger again while the func is still running
    
            public Debouncer(int millisecondsToWait = 300)
            {
                this.MillisecondsToWait = millisecondsToWait;
            }
    
            public void Debouce(Action func)
            {
                CancelAllStepperTokens(); // Cancel all api requests;
                var newTokenSrc = new CancellationTokenSource();
                lock (_lockThis)
                    StepperCancelTokens.Add(newTokenSrc);
                Task.Delay(MillisecondsToWait, newTokenSrc.Token).ContinueWith(task => // Create new request
                {
                    if (!newTokenSrc.IsCancellationRequested) // if it hasn't been cancelled
                    {
                        CancelAllStepperTokens(); // Cancel any that remain (there shouldn't be any)
                        StepperCancelTokens = new List<CancellationTokenSource>(); // set to new list
                        lock (_lockThis)
                            func(); // run
                    }
                });
            }
    
            private void CancelAllStepperTokens()
            {
                foreach (var token in StepperCancelTokens)
                {
                    if (!token.IsCancellationRequested)
                    {
                        token.Cancel();
                    }
                }
            }
        }
    }
