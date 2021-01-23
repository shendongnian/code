        public Task<int> RunOnUi(Func<int> f)
        {
            var operation = Application.Current.Dispatcher.BeginInvoke(f);
            var tcs = new TaskCompletionSource<int>();
            operation.Aborted += (sender, args) => tcs.TrySetException(new SomeExecptionHere());
            operation.Completed += (sender, args) => tcs.TrySetResult((int)operation.Result);
            //The operation may have already finished and this check accounts for 
            //the race condition where neither of the events will ever be called
            //because the events where raised before you subscribed.
            var status = operation.Status;
            if (status == DispatcherOperationStatus.Completed)
            {
                tcs.TrySetResult((int)operation.Result);
            }
            else if (status == DispatcherOperationStatus.Aborted)
            {
                tcs.TrySetException(new SomeExecptionHere());
            }
            return tcs.Task;
        }
