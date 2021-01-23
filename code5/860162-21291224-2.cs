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
                // create and hide the host window
                var hostWindow = new Window();
                hostWindow.Visibility = Visibility.Hidden;
                hostWindow.Show();
                // create WebBrowser
                var wb = new WebBrowser();
                hostWindow.Content = wb;
                // suppress script errors: http://stackoverflow.com/a/18289217
                // touching wb.Document makes sure the ActiveX has been created
                dynamic document = wb.Document; 
                dynamic activeX = wb.GetType().InvokeMember("ActiveXInstance",
                    BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, wb, new object [] { });
                activeX.Silent = true;
                // navigate
                var navigationTcs = new TaskCompletionSource<bool>();
                wb.LoadCompleted += (s, e) => 
                    navigationTcs.TrySetResult(true);
                wb.Navigate("http://www.example.com");
                await navigationTcs.Task;
                // log the content etc.
                document = wb.Document;
                resultTcs.SetResult((string)document.body.outerHTML);
            }
            catch (Exception ex)
            {
                resultTcs.SetException(ex);
            }
            // terminate the tread: the loop by Dispatcher.Run() will exit
            Dispatcher.ExitAllFrames();
        };
        // thread procedure
        ThreadStart threadStart = () =>
        {
            // post a startup callback
            Dispatcher.CurrentDispatcher.BeginInvoke(startup);
            // run the message loop
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
            thread.Join();
        }
    }
