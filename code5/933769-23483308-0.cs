    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace TaskProgress
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private async void Form1_Load(object sender, EventArgs e)
            {
                await DoWorkAsync();
            }
    
            const int MAX_PARALLEL = 4;
    
            readonly object _lock = new Object();
            readonly SemaphoreSlim _semaphore = 
                new SemaphoreSlim(initialCount: MAX_PARALLEL);
            HashSet<Task> _pendingTasks;
            Queue<ProgressBar> _availableProgressBar;
    
            // do all Task
            async Task DoWorkAsync()
            {
                _availableProgressBar = new Queue<ProgressBar>();
                _pendingTasks = new HashSet<Task>();
    
                var progressBars = new ProgressBar[] { 
                    this.progressBar1, 
                    this.progressBar2, 
                    this.progressBar3, 
                    this.progressBar4 };
                foreach (var item in progressBars)
                    _availableProgressBar.Enqueue(item);
    
                for (int i = 0; i < 50; i++) // start 50 tasks
                    QueueTaskAsync(DoTaskAsync());
    
                await Task.WhenAll(WithLock(() => _pendingTasks.ToArray()));
            }
    
            // do a sigle Task
            readonly Random _random = new Random(Environment.TickCount);
    
            async Task DoTaskAsync()
            {
                await _semaphore.WaitAsync();
                try
                {
                    var progressBar = WithLock(() => _availableProgressBar.Dequeue());
                    try
                    {
                        progressBar.Maximum = 100;
                        progressBar.Value = 0;
                        IProgress<int> progress = 
                            new Progress<int>(value => progressBar.Value = value);
                        await Task.Run(() =>
                        {
                            // our simulated work takes no more than 10s
                            var sleepMs = _random.Next(10000) / 100;
                            for (int i = 0; i < 100; i++)
                            {
                                Thread.Sleep(sleepMs); // simulate work item
                                progress.Report(i);
                            }
                        });
                    }
                    finally
                    {
                        WithLock(() => _availableProgressBar.Enqueue(progressBar));
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            }
    
            // Add/remove a task to the list of pending tasks
            async void QueueTaskAsync(Task task)
            {
                WithLock(() => _pendingTasks.Add(task));
                try
                {
                    await task;
                }
                catch
                {
                    if (!task.IsCanceled && !task.IsFaulted)
                        throw;
                    return;
                }
                WithLock(() => _pendingTasks.Remove(task));
            }
    
            // execute func inside a lock
            T WithLock<T>(Func<T> func)
            {
                lock (_lock)
                    return func();
            }
    
            // execute action inside a lock
            void WithLock(Action action)
            {
                lock (_lock)
                    action();
            }
    
        }
    }
