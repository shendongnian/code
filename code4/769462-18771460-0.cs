    // The window is shown perfectly.
    m_WaitWindow.Show();
    ThreadPool.QueueUserWorkItem(arg =>
        {
            Thread.Sleep(5000);
            Dispatcher.BeginInvoke(new Action(() => m_WaitWindow.Hide()));
            Thread.Sleep(2000);
            // The window is still shown perfectly, because the UI thread is not being blocked.
            Dispatcher.BeginInvoke(new Action(() => m_WaitWindow.Show()));
            Thread.Sleep(5000);
            Dispatcher.BeginInvoke(new Action(() => m_WaitWindow.Hide()));
        }, null);
