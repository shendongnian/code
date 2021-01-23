    static Task Delay(int delayTime, System.Threading.CancellationToken token)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            if (delayTime < 0) throw new ArgumentOutOfRangeException("Delay time cannot be under 0");
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer(p =>
            {
                timer.Dispose(); //stop the timer
                tcs.TrySetResult(null); //timer expired, attempt to move task to the completed state.
            }, null, delayTime, System.Threading.Timeout.Infinite);
            token.Register(() =>
                {
                    timer.Dispose(); //stop the timer
                    tcs.TrySetCanceled(); //attempt to mode task to canceled state
                });
            return tcs.Task;
        }
