    static async Task<string> RunWpfWebBrowserAsync(string url)
    {
        // return the result via Task
        var resultTcs = new TaskCompletionSource<string>();
        // the main WPF WebBrowser driving logic
        // to be executed on an STA thread
        Action startup = async () => 
        {
            try
            {
                // create host window
                var hostWindow = new Window();
                hostWindow.ShowActivated = false;
                hostWindow.ShowInTaskbar = false;
                hostWindow.Visibility = Visibility.Hidden;
                hostWindow.Show();
                // create a WPF WebBrowser instance
                var wb = new WebBrowser();
                hostWindow.Content = wb;
                // suppress script errors: http://stackoverflow.com/a/18289217
                // touching wb.Document makes sure the underlying ActiveX has been created
                dynamic document = wb.Document; 
                dynamic activeX = wb.GetType().InvokeMember("ActiveXInstance",
                    BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, wb, new object [] { });
                activeX.Silent = true;
                // navigate and handle LoadCompleted
                var navigationTcs = new TaskCompletionSource<bool>();
                wb.LoadCompleted += (s, e) => 
                    navigationTcs.TrySetResult(true);
                wb.Navigate(url);
                await navigationTcs.Task;
                // do the WebBrowser automation
                document = wb.Document;
                // ...
                // return the content (for example)
                string content = document.body.outerHTML;
                resultTcs.SetResult(content);
            }
            catch (Exception ex)
            {
                // propogate exceptions to the caller of RunWpfWebBrowserAsync
                resultTcs.SetException(ex);
            }
            // end the tread: the message loop inside Dispatcher.Run() will exit
            Dispatcher.ExitAllFrames();
        };
        // thread procedure
        ThreadStart threadStart = () =>
        {
            // post the startup callback
            Dispatcher.CurrentDispatcher.BeginInvoke(startup);
            // run the WPF Dispatcher message loop
            Dispatcher.Run();
            Debug.Assert(true);
        };
        // start and run the STA thread
        var thread = new Thread(threadStart);
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        try
        {
            // use Task.ConfigureAwait(false) to avoid deadlock on a UI thread
            // if the caller does a blocking call, i.e.:
            // "RunWpfWebBrowserAsync(url).Wait()" or 
            // "RunWpfWebBrowserAsync(url).Result"
            return await resultTcs.Task.ConfigureAwait(false);
        }
        finally
        {
            // make sure the thread has fully come to an end
            thread.Join();
        }
    }
