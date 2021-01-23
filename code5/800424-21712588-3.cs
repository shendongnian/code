    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Console_19613444
    {
        class Program
        {
            // http://stackoverflow.com/a/19616899/1768303
            // Based on http://blogs.msdn.com/b/pfxteam/archive/2013/01/13/cooperatively-pausing-async-methods.aspx
    
            public class PauseTokenSource
            {
                internal static readonly Task s_completedTask = Task.FromResult(false);
    
                readonly object _lock = new Object();
    
                bool _paused = false;
    
                SynchronizationContext _pauseResponseContext;
                TaskCompletionSource<bool> _pauseResponseTcs;
    
                SynchronizationContext _resumeRequestContext;
                TaskCompletionSource<bool> _resumeRequestTcs;
    
                public PauseToken Token { get { return new PauseToken(this); } }
    
                public bool IsPaused
                {
                    get
                    {
                        lock (_lock)
                            return _paused;
                    }
                }
    
                // resume
                public void Resume()
                {
                    TaskCompletionSource<bool> resumeRequestTcs = null;
                    SynchronizationContext resumeRequestContext = null;
    
                    lock (_lock)
                    {
                        resumeRequestTcs = _resumeRequestTcs;
                        resumeRequestContext = _resumeRequestContext;
    
                        _resumeRequestTcs = null;
                        _resumeRequestContext = null;
    
                        if (!_paused)
                            return;
                        _paused = false;
                    }
    
                    if (resumeRequestTcs != null)
                        Reply(() => resumeRequestTcs.TrySetResult(true), resumeRequestContext);
                }
    
                // pause with feedback
                public Task PauseAsync()
                {
                    Task responseTask = null;
    
                    lock (_lock)
                    {
                        if (_paused)
                            return _pauseResponseTcs.Task;
                        _paused = true;
    
                        _pauseResponseContext = SynchronizationContext.Current;
                        _pauseResponseTcs = new TaskCompletionSource<bool>();
                        responseTask = _pauseResponseTcs.Task;
    
                        _resumeRequestTcs = null;
                        _resumeRequestContext = null;
                    }
    
                    return responseTask;
                }
    
                // wait while paused
                internal Task WaitForResumeAsync()
                {
                    Task resumeTask = s_completedTask;
                    TaskCompletionSource<bool> pauseResponseTcs = null;
                    SynchronizationContext pauseResponseContext = null;
    
                    lock (_lock)
                    {
                        if (!_paused)
                            return s_completedTask;
    
                        _resumeRequestContext = SynchronizationContext.Current;
                        _resumeRequestTcs = new TaskCompletionSource<bool>();
                        resumeTask = _resumeRequestTcs.Task;
    
                        pauseResponseTcs = _pauseResponseTcs;
                        pauseResponseContext = _pauseResponseContext;
    
                        _pauseResponseTcs = null;
                        _pauseResponseContext = null;
                    }
    
                    if (pauseResponseTcs != null)
                        Reply(() => pauseResponseTcs.TrySetResult(true), pauseResponseContext);
    
                    return resumeTask;
                }
    
                // reply helper
                static void Reply(Action action, SynchronizationContext context)
                {
                    // avoid deadlocks
                    if (context == null)
                        ThreadPool.QueueUserWorkItem((a) => ((Action)a)(), action);
                    else
                        context.Post((a) => ((Action)a)(), action);
                }
            }
    
            // consumer side
            public struct PauseToken
            {
                readonly PauseTokenSource _source;
    
                public PauseToken(PauseTokenSource source) { _source = source; }
    
                public bool IsPaused { get { return _source != null && _source.IsPaused; } }
    
                public Task WaitForResumeAsync()
                {
                    return IsPaused ?
                        _source.WaitForResumeAsync() :
                        PauseTokenSource.s_completedTask;
                }
            }
    
    
            // Testing
    
            public static async Task DoWorkAsync(PauseToken pause, CancellationToken token)
            {
                try
                {
                    while (true)
                    {
                        token.ThrowIfCancellationRequested();
    
                        await Task.Delay(1000).ConfigureAwait(false);
                        Console.WriteLine("Before await pause.WaitForResumeAsync()");
                        await pause.WaitForResumeAsync();
                        Console.WriteLine("After await pause.WaitForResumeAsync()");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e);
                    throw;
                }
            }
    
            static async Task Test(CancellationToken token)
            {
                var pts = new PauseTokenSource();
                var task = DoWorkAsync(pts.Token, token);
    
                while (true)
                {
                    token.ThrowIfCancellationRequested();
    
                    Console.WriteLine("Press enter to pause...");
                    Console.ReadLine();
    
                    Console.WriteLine("Before pause requested");
                    await pts.PauseAsync();
                    Console.WriteLine("After pause requested, paused: " + pts.IsPaused);
    
                    Console.WriteLine("Press enter to resume...");
                    Console.ReadLine();
    
                    Console.WriteLine("Before resume");
                    pts.Resume();
                    Console.WriteLine("After resume");
                }
            }
    
            static void Main()
            {
                Test(CancellationToken.None).Wait();
            }
        }
    }
