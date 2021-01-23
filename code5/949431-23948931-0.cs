    public void LoadTimer()
    {
        int sec = 0;
        Timer timer = new Timer((obj) =>
        {
            Dispatcher pageDispatcher = obj as Dispatcher;
            pageDispatcher.BeginInvoke(() =>
            {
                sec++;
                TimerTextBlock.Text = sec.ToString();
            });
        }, this.Dispatcher, 1000, 1000);
    }
