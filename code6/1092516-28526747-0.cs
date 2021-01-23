    public static void ListenerThread()
    {
        while (true)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                System.Diagnostics.Debug.WriteLine("Left mouse down");
            }
            Thread.Sleep(1000);
        }
    }
