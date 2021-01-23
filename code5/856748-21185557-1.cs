    public  static class TimeOutHelper
    {
        private class ObjectState
        {
            public Action predict { get; set; }
            public AutoResetEvent autoEvent { get; set; }
        }
        public static bool ExecuteMethod(Action predict, int timeOutInterval, int retryCounter = 1)
        {
            bool IsFinished = false;
            ObjectState objectState = new ObjectState();
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            int timeOutInt = timeOutInterval > 0 ? timeOutInterval: Timeout.Infinite;
            objectState.autoEvent = autoEvent;
            objectState.predict = predict;
            Timer timer = null;
            var callbackMethod = new TimerCallback(TimerCallbackMethod);
            timer = new Timer(callbackMethod, objectState, 0, timeOutInt+5);
    
            try
            {
                for (int i = 0; i < retryCounter; i++)
                {
                    var isSignal = autoEvent.WaitOne(timeOutInt, false);
                    if (isSignal)
                     break; 
                    if (retryCounter - 1 == i) throw new TimeoutException();
                    else
                        timer.Change(0, timeOutInt);
                }
            }
            finally
            {
                IsFinished = true;
                if (autoEvent != null)
                    autoEvent.Dispose();
                if (timer != null)
                    timer.Dispose();
            }
            return IsFinished;
        }
        private static void TimerCallbackMethod(object state)
        {
            var objectSate = (ObjectState)state;
            var predict = (Action)objectSate.predict;
            predict();
            if(objectSate!=null && !objectSate.autoEvent.SafeWaitHandle.IsClosed)
                objectSate.autoEvent.Set();
        }
    }
