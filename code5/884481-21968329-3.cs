    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Console_21628490
    {
        // Test
        class Program
        {
            static async Task DoWorkAsync()
            {
                Console.WriteLine("Initial thread: " + Thread.CurrentThread.ManagedThreadId);
    
                // the worker thread lambda
                Func<WorkerWithTaskScheduler<int>, int> workAction = (worker) =>
                {
                    var result = 0;
    
                    Console.WriteLine("Worker thread: " + Thread.CurrentThread.ManagedThreadId);
    
                    while (worker.ContinueExecution)
                    {
                        // observe cancellation
                        worker.Token.ThrowIfCancellationRequested();
    
                        // executed pending tasks scheduled with WorkerWithTaskScheduler.Run
                        worker.ExecutePendingTasks();
    
                        // do the work item
                        Thread.Sleep(200); // simulate work payload
                        result++;
    
                        Console.Write("\rDone so far: " + result);
                        if (result > 100)
                            break; // done after 100 items
                    }
                    return result;
                };
    
                try
                {
                    // cancel in 30s
                    var cts = new CancellationTokenSource(30000);
                    // start the worker
                    var worker = new WorkerWithTaskScheduler<int>(workAction, cts.Token);
    
                    // pause upon Enter
                    Console.WriteLine("\nPress Enter to pause...");
                    Console.ReadLine();
                    worker.WaitForPendingTasks = true;
    
                    // resume upon Enter
                    Console.WriteLine("\nPress Enter to resume...");
                    Console.ReadLine();
                    worker.WaitForPendingTasks = false;
    
                    // send a "message", i.e. run a lambda inside the worker thread
                    var response = await worker.Run(() =>
                    {
                        // do something in the context of the worker thread
                        return Thread.CurrentThread.ManagedThreadId;
                    }, cts.Token);
                    Console.WriteLine("\nReply from Worker thread: " + response);
    
                    // End upon Enter
                    Console.WriteLine("\nPress Enter to stop...");
                    Console.ReadLine();
    
                    // worker.EndExecution() to get the result gracefully
                    worker.ContinueExecution = false; // or worker.Cancel() to throw
                    var result = await worker.WorkerTask;
    
                    Console.Write("\nFinished, result: " + result);
                }
                catch (Exception ex)
                {
                    while (ex is AggregateException)
                        ex = ex.InnerException;
                    Console.WriteLine(ex.Message);
                }
            }
    
            static void Main(string[] args)
            {
                DoWorkAsync().Wait();
                Console.WriteLine("\nPress Enter to Exit.");
                Console.ReadLine();
            }
        }
    
        //
        // WorkerWithTaskScheduler
        //
    
        public class WorkerWithTaskScheduler<TResult> : TaskScheduler, IDisposable
        {
            readonly CancellationTokenSource _workerCts;
            Task<TResult> _workerTask;
    
            readonly BlockingCollection<Task> _pendingTasks;
            Thread _workerThread;
    
            volatile bool _continueExecution = true;
            volatile bool _waitForTasks = false;
    
            // start the main loop
            public WorkerWithTaskScheduler(
                Func<WorkerWithTaskScheduler<TResult>, TResult> executeMainLoop,
                CancellationToken token)
            {
                _pendingTasks = new BlockingCollection<Task>();
                _workerCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    
                _workerTask = Task.Factory.StartNew<TResult>(() =>
                {
                    _workerThread = Thread.CurrentThread;
                    return executeMainLoop(this);
                }, _workerCts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
    
            // a sample action for WorkerWithTaskScheduler constructor
            public static void ExecuteMainLoop(WorkerWithTaskScheduler<TResult> worker)
            {
                while (!worker.ContinueExecution)
                {
                    worker.Token.ThrowIfCancellationRequested();
                    worker.ExecutePendingTasks();
                }
            }
    
            // get the Task
            public Task<TResult> WorkerTask
            {
                get { return _workerTask; }
            }
    
            // get CancellationToken 
            public CancellationToken Token
            {
                get { return _workerCts.Token; }
            }
    
            // check/set if the main loop should continue
            public bool ContinueExecution
            {
                get { return _continueExecution; }
                set { _continueExecution = value; }
            }
    
            // request cancellation
            public void Cancel()
            {
                _workerCts.Cancel();
            }
    
            // check if we're on the correct thread
            public void VerifyWorkerThread()
            {
                if (Thread.CurrentThread != _workerThread)
                    throw new InvalidOperationException("Invalid thread.");
            }
    
            // check if the worker task itself is still alive
            public void VerifyWorkerTask()
            {
                if (_workerTask == null || _workerTask.IsCompleted)
                    throw new InvalidOperationException("The worker thread has ended.");
            }
    
            // make ExecutePendingTasks block or not block
            public bool WaitForPendingTasks
            {
                get { return _waitForTasks; }
                set 
                { 
                    _waitForTasks = value;
                    if (value) // wake it up
                        Run(() => { }, this.Token);
                }
            }
    
            // execute all pending tasks and return
            public void ExecutePendingTasks()
            {
                VerifyWorkerThread();
    
                while (this.ContinueExecution)
                {
                    this.Token.ThrowIfCancellationRequested();
    
                    Task item;
                    if (_waitForTasks)
                    {
                        item = _pendingTasks.Take(this.Token);
                    }
                    else
                    {
                        if (!_pendingTasks.TryTake(out item))
                            break;
                    }
    
                    TryExecuteTask(item);
                }
            }
    
            //
            // TaskScheduler methods
            //
    
            protected override void QueueTask(Task task)
            {
                _pendingTasks.Add(task);
            }
    
            protected override IEnumerable<Task> GetScheduledTasks()
            {
                return _pendingTasks.ToArray();
            }
    
            protected override bool TryExecuteTaskInline(
                Task task, bool taskWasPreviouslyQueued)
            {
                return _workerThread == Thread.CurrentThread &&
                    TryExecuteTask(task);
            }
    
            public override int MaximumConcurrencyLevel
            {
                get { return 1; }
            }
    
            public void Dispose()
            {
                if (_workerTask != null)
                {
                    _workerCts.Cancel();
                    _workerTask.Wait();
                    _pendingTasks.Dispose();
                    _workerTask = null;
                }
            }
    
            //
            // Task.Factory.StartNew wrappers using this task scheduler
            //
    
            public Task Run(Action action, CancellationToken token)
            {
                VerifyWorkerTask();
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this);
            }
    
            public Task<T> Run<T>(Func<T> action, CancellationToken token)
            {
                VerifyWorkerTask();
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this);
            }
    
            public Task Run(Func<Task> action, CancellationToken token)
            {
                VerifyWorkerTask();
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this).Unwrap();
            }
    
            public Task<T> Run<T>(Func<Task<T>> action, CancellationToken token)
            {
                VerifyWorkerTask();
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this).Unwrap();
            }
        }
    }
