    public new void Hide()
        {
            Dispatcher.Invoke(() =>
            {
                base.Hide();
                WindowState = WindowState.Minimized;
                base.OnStateChanged(new EventArgs());
            });
        }
        public new void Show()
        {
            Dispatcher.Invoke(() =>
            {
                base.Show();
                base.Topmost = true;
                WindowState = WindowState.Normal;
            });
        }
