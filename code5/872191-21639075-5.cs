    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace Wpf_21611292
    {
        // Model
        public class ViewModel : INotifyPropertyChanged
        {
            string _data;
    
            public string Data
            {
                get
                {
                    return _data;
                }
                set
                {
                    if (_data != value)
                    {
                        _data = value;
                        if (this.PropertyChanged != null)
                            PropertyChanged(this, new PropertyChangedEventArgs("Data"));
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        // MainWindow
        public partial class MainWindow : Window
        {
            ViewModel _model = new ViewModel { Data = "Hello!" };
    
            AsyncOp _asyncOp = new AsyncOp();
            
            CancellationTokenSource _myFunctionCts = new CancellationTokenSource();
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = _model;
    
    
                this.Loaded += MainWindow_Loaded;
                this.SizeChanged += MainWindow_SizeChanged;
            }
    
            void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                _asyncOp.RunAsync(MyFunctionAsync, _myFunctionCts.Token);
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                _asyncOp.RunAsync(MyFunctionAsync, _myFunctionCts.Token);
            }
    
            async Task MyFunctionAsync(CancellationToken token)
            {
                int width = (int)this.Width;
                var text = await Task.Run(() =>
                {
                    int i;
                    for (i = 0; i < 10000000; i++)
                    {
                        if (token.IsCancellationRequested)
                            break;
                    }
                    return i;
                }, token);
    
                // update ViewModel
                _model.Data = "Width: " + width.ToString() + "/" + text;
            }
        }
    
        // AsyncOp
        class AsyncOp
        {
            Task _pendingTask = null;
            CancellationTokenSource _pendingCts = null;
    
            public Task PendingTask { get { return _pendingTask; } }
    
            public void Cancel()
            {
                if (_pendingTask != null && !_pendingTask.IsCompleted)
                    _pendingCts.Cancel();
            }
    
            public Task RunAsync(Func<CancellationToken, Task> routine, CancellationToken token)
            {
                var oldTask = _pendingTask;
                var oldCts = _pendingCts;
    
                var thisCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    
                Func<Task> startAsync = async () =>
                {
                    // await the old task
                    if (oldTask != null && !oldTask.IsCompleted)
                    {
                        oldCts.Cancel();
                        try
                        {
                            await oldTask;
                        }
                        catch (Exception ex)
                        {
                            while (ex is AggregateException)
                                ex = ex.InnerException;
                            if (!(ex is OperationCanceledException))
                                throw;
                        }
                    }
                    // run and await this task
                    await routine(thisCts.Token);
                };
    
                _pendingCts = thisCts;
    
                _pendingTask = Task.Factory.StartNew(
                    startAsync,
                    _pendingCts.Token,
                    TaskCreationOptions.None,
                    TaskScheduler.FromCurrentSynchronizationContext()).Unwrap();
    
                return _pendingTask;
            }
        }
    }
