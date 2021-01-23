        bool executing;
        public TestOperation(Action callBackMethod)
        {
            this.timer = new System.Threading.Timer(timer_Elapsed, callbackMethod, timerInterval, Timeout.Infinite);
        }
        private void timer_Elapsed(object state)
        {
            lock(this)
            {
                if(executing)
                    return;
                Action callback = (Action) state;
                if (callback != null)
                {
                    executing = true;
                    callback();
                }
            }
        }
        // example of the callback, in another class. 
        private void callBackMethod()
        {
            // How can I stop this from running every 1 second? Lock() doesn't seem to work here
            lock(this)
            {
                Thread.Sleep(2000);
                executing = false;
            }
        }
