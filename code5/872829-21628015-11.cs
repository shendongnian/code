    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;
    
    namespace Wpf_21626242
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Content = new TextBox();
    
                this.Loaded += MainWindow_Loaded;
            }
    
            async void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                try
                {
                    // cancel in 10s
                    var cts = new CancellationTokenSource(10000);
                    var token = cts.Token;
                    var buffer = new Buffer<int>();
    
                    // background worker task
                    var workerTask = Task.Run(() =>
                    {
                        var start = Environment.TickCount;
                        while (true)
                        {
                            token.ThrowIfCancellationRequested();
                            Thread.Sleep(50);
                            buffer.PutData(Environment.TickCount - start);
                        }
                    });
    
                    // the UI thread task
                    while (true)
                    {
                        // yield to keep the UI responsive
                        await Dispatcher.Yield(DispatcherPriority.Background);
    
                        // get the current data item
                        var result = await buffer.GetData(token);
    
                        // update the UI (or ViewModel)
                        ((TextBox)this.Content).Text = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
            /// <summary>Consumer/producer async buffer for single data item</summary>
            public class Buffer<T>
            {
                volatile TaskCompletionSource<T> _tcs = new TaskCompletionSource<T>();
                object _lock = new Object();  // protect _tcs
    
                // consumer
                public async Task<T> GetData(CancellationToken token)
                {
                    Task<T> task = null;
    
                    lock (_lock)
                        task = _tcs.Task;
    
                    try
                    {
                        // observe cancellation
                        var cancellationTcs = new TaskCompletionSource<bool>();
                        using (token.Register(() => cancellationTcs.SetCanceled(),
                            useSynchronizationContext: false))
                        {
                            await Task.WhenAny(task, cancellationTcs.Task).ConfigureAwait(false);
                        }
    
                        token.ThrowIfCancellationRequested();
    
                        // return the data item
                        return await task.ConfigureAwait(false);
                    }
                    finally
                    {
                        // get ready for the next data item
                        lock (_lock)
                            if (_tcs.Task == task && task.IsCompleted)
                                _tcs = new TaskCompletionSource<T>();
                    }
                }
    
                // producer
                public void PutData(T data)
                {
                    TaskCompletionSource<T> tcs;
                    lock (_lock)
                    {
                        if (_tcs.Task.IsCompleted)
                            _tcs = new TaskCompletionSource<T>();
                        tcs = _tcs;
                    }
                    tcs.SetResult(data);
                }
            }
    
        }
    }
 
