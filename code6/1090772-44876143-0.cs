    public class DebounceDispatcher
    {
        private DispatcherTimer timer;
    
        public void Debounce(int timeout, Action<object> action, 
            object param = null,
            DispatcherPriority priority = DispatcherPriority.ApplicationIdle,
            Dispatcher disp = null)
        {
            if (disp == null)
                disp = Dispatcher.CurrentDispatcher;
    
            if (timer == null)
            {
                timer = new DispatcherTimer(TimeSpan.FromMilliseconds(timeout), priority, 
                    (s, e) =>
                    {
                        timer.IsEnabled = false;
                        action.Invoke(param);
                    }, disp)
                    {IsEnabled = true};
            }
            else
                timer.IsEnabled = false;
    
            timer.IsEnabled = true;
        }
    }    
