    public static async Task RunAsync()
    {
        using (var staThread = new Noseratio.ThreadAffinity.ThreadWithAffinityContext(staThread: true, pumpMessages: true))
        {
            Console.WriteLine("Initial thread #" + Thread.CurrentThread.ManagedThreadId);
            await staThread.Run(async () =>
            {
                Console.WriteLine("On STA thread #" + Thread.CurrentThread.ManagedThreadId);
                // create a simple Win32 window
                IntPtr hwnd = CreateTestWindow();
    
                // Post some WM_TEST messages
                Console.WriteLine("Post some WM_TEST messages...");
                NativeMethods.PostMessage(hwnd, NativeMethods.WM_TEST, new IntPtr(1), IntPtr.Zero);
                NativeMethods.PostMessage(hwnd, NativeMethods.WM_TEST, new IntPtr(2), IntPtr.Zero);
                NativeMethods.PostMessage(hwnd, NativeMethods.WM_TEST, new IntPtr(3), IntPtr.Zero);
                Console.WriteLine("Press Enter to continue...");
                await ReadLineAsync();
    
                Console.WriteLine("After await, thread #" + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Pending messages in the queue: " + (NativeMethods.GetQueueStatus(0x1FF) >> 16 != 0));
    
                Console.WriteLine("Exiting STA thread #" + Thread.CurrentThread.ManagedThreadId);
            }, CancellationToken.None);
        }
        Console.WriteLine("Current thread #" + Thread.CurrentThread.ManagedThreadId);
    }
