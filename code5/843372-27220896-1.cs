    Task f = Task.Factory.StartNew(() =>
    {
    while (Process.GetProcessesByName("notepad").Length == 0)
        {
            System.Threading.Thread.Sleep(1000); //Does the while loop every 1000 ms
        }
    });
