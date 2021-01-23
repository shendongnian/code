    private Signaller signal = new Signaller();
    private void Work()
    {
        while (true)
        {
            Thread.Sleep(5000);
            signal.Pulse(); // Or signal.PulseAll() to signal ALL waiting threads.
        }
    }
    public void WaitForNextEvent()
    {
        signal.Wait();
    }
