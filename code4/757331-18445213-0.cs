    private delegate void EventHandle();
    private void loading()
    {
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(10);
            Invoke(new EventHandle{progressBar1.Value++;})
        }
    }
