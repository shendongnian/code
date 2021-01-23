    if (GetLastInputInfo(ref LastInput))
    {
        IdleTime = System.Environment.TickCount - LastInput.dwTime;
        string s = IdleTime.ToString();
        
        Dispatcher.BeginInvoke(new Action(() =>
        {
            label1.Content = s;
        }));
    }
