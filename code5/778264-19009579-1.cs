    while (true)
    {
        if (_number++ > 10000)
            _number = 0;
        int copy = _number;
        this.Dispatcher.BeginInvoke(new Action(() => UpdateText(copy))
            , System.Windows.Threading.DispatcherPriority.Background, null);
        Thread.Sleep(200);
    }
---
    private void UpdateText(int number)
    {
        this.Text = number.ToString();
    }
