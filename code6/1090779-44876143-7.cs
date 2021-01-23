        public void Throttle(int interval, Action<object> action,
            object param = null,
            DispatcherPriority priority = DispatcherPriority.ApplicationIdle,
            Dispatcher disp = null)
        {
            // kill pending timer and pending ticks
            timer?.Stop();
            timer = null;
            if (disp == null)
                disp = Dispatcher.CurrentDispatcher;
            var curTime = DateTime.UtcNow;
            // if timeout is not up yet - adjust timeout to fire 
            // with potentially new Action parameters           
            if (curTime.Subtract(timerStarted).TotalMilliseconds < interval)
                interval = (int) curTime.Subtract(timerStarted).TotalMilliseconds;
            timer = new DispatcherTimer(TimeSpan.FromMilliseconds(interval), priority, (s, e) =>
            {
                if (timer == null)
                    return;
                timer?.Stop();
                timer = null;
                action.Invoke(param);
            }, disp);
            timer.Start();
            timerStarted = curTime;            
        }
