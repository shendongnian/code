    private Timer t;
    public void OnLoad()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            StartTopmostTimer(window);
        }
        private void StartTopmostTimer(Window window)
        {
            t = new Timer(o => SetTopMostFalse(window), null, 1000, Timeout.Infinite);
        }
        private void SetTopMostFalse(Window window)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                window.Topmost = false;
            }));
            t.Dispose();
        }
