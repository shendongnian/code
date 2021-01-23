    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfAsyncApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Content = new TextBox();
                this.Loaded += MainWindow_Loaded;
            }
    
            // AsyncWork
            async Task AsyncWork(int n, CancellationToken token)
            {
                // prepare the modal UI window
                var modalUI = new Window();
                modalUI.Width = 300; modalUI.Height = 200;
                modalUI.Content = new TextBox();
    
                try
                {
                    using (var client = new HttpClient())
                    {
                        // main loop
                        for (var i = 0; i < n; i++)
                        {
                            token.ThrowIfCancellationRequested();
    
                            // do the next step of async process
                            var data = await client.GetStringAsync("http://www.bing.com/search?q=item" + i);
    
                            // update the main window status
                            var info = "#" + i + ", size: " + data.Length + Environment.NewLine;
                            ((TextBox)this.Content).AppendText(info);
    
                            // show the modal UI if the data size is more than 42000 bytes (for example)
                            if (data.Length < 42000)
                            {
                                if (!modalUI.IsVisible)
                                {
                                    // show the modal UI window asynchronously
                                    await ShowDialogAsync(modalUI, token);
                                    // continue while the modal UI is still visible
                                }
                            }
    
                            // update modal window status, if visible
                            if (modalUI.IsVisible)
                                ((TextBox)modalUI.Content).AppendText(info);
                        }
                    }
    
                    // wait for the user to close the dialog (if open)
                    if (modalUI.IsVisible)
                        await CloseDialogAsync(modalUI, token);
                }
                finally
                {
                    // always close the window
                    modalUI.Close();
                }
            }
    
            // show a modal dialog asynchronously
            static async Task ShowDialogAsync(Window window, CancellationToken token)
            {
                var tcs = new TaskCompletionSource<bool>();
                using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
                {
                    RoutedEventHandler loadedHandler = (s, e) =>
                        // async call to make sure all other Load handlers have been executed first
                        SynchronizationContext.Current.Post((_) => 
                            tcs.TrySetResult(true), null);
    
                    window.Loaded += loadedHandler;
                    try
                    {
                        // show the dialog asynchronously 
                        // (presumably on the next iteration of the message loop)
                        SynchronizationContext.Current.Post((_) => 
                            window.ShowDialog(), null);
                        await tcs.Task;
                    }
                    finally
                    {
                        window.Loaded -= loadedHandler;
                    }
                }
            }
    
            // async wait for a dialog to get closed
            static async Task CloseDialogAsync(Window window, CancellationToken token)
            {
                var tcs = new TaskCompletionSource<bool>();
                using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
                {
                    EventHandler closedHandler = (s, e) =>
                        // async call to make sure the nested message loop ended first
                        SynchronizationContext.Current.Post((_) =>
                            tcs.TrySetResult(true), null);
    
                    window.Closed += closedHandler;
                    try
                    {
                        await tcs.Task;
                    }
                    finally
                    {
                        window.Closed -= closedHandler;
                    }
                }
            }
    
            // main window load event handler
            async void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var cts = new CancellationTokenSource(30000);
                try
                {
                    // test AsyncWork
                    await AsyncWork(10, cts.Token);
                    MessageBox.Show("Success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
