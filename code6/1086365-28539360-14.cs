    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                StartAndControlWorkAsync(CancellationToken.None).Wait();
            }
    
            // Do some work which can be paused/resumed
            public static async Task DoWorkAsync(PauseToken pause, CancellationToken token)
            {
                try
                {
                    var step = 0;
                    while (true)
                    {
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine("Working, step: " + step++);
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
    
            // Start DoWorkAsync and pause/resume it
            static async Task StartAndControlWorkAsync(CancellationToken token)
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
    
            // Based on Stephen Toub's PauseTokenSource
            // http://blogs.msdn.com/b/pfxteam/archive/2013/01/13/cooperatively-pausing-async-methods.aspx
            // the main difference is to make sure that when the consumer-side code - which requested the pause - continues, 
            // the producer-side code has already reached the paused (awaiting) state.
            // E.g. a media player "Pause" button is clicked, gets disabled, playback stops, 
            // and only then "Resume" button gets enabled
    
            public class PauseTokenSource
            {
                internal static readonly Task s_completedTask = Task.Delay(0);
    
                readonly object _lock = new Object();
    
                bool _paused = false;
    
                TaskCompletionSource<bool> _pauseResponseTcs;
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
    
                // request a resume
                public void Resume()
                {
                    TaskCompletionSource<bool> resumeRequestTcs = null;
    
                    lock (_lock)
                    {
                        resumeRequestTcs = _resumeRequestTcs;
                        _resumeRequestTcs = null;
    
                        if (!_paused)
                            return;
                        _paused = false;
                    }
    
                    if (resumeRequestTcs != null)
                        resumeRequestTcs.TrySetResult(true, asyncAwaitContinuations: true);
                }
    
                // request a pause (completes when paused state confirmed)
                public Task PauseAsync()
                {
                    Task responseTask = null;
    
                    lock (_lock)
                    {
                        if (_paused)
                            return _pauseResponseTcs.Task;
                        _paused = true;
    
                        _pauseResponseTcs = new TaskCompletionSource<bool>();
                        responseTask = _pauseResponseTcs.Task;
    
                        _resumeRequestTcs = null;
                    }
    
                    return responseTask;
                }
    
                // wait for resume request
                internal Task WaitForResumeAsync()
                {
                    Task resumeTask = s_completedTask;
                    TaskCompletionSource<bool> pauseResponseTcs = null;
    
                    lock (_lock)
                    {
                        if (!_paused)
                            return s_completedTask;
    
                        _resumeRequestTcs = new TaskCompletionSource<bool>();
                        resumeTask = _resumeRequestTcs.Task;
    
                        pauseResponseTcs = _pauseResponseTcs;
    
                        _pauseResponseTcs = null;
                    }
    
                    if (pauseResponseTcs != null)
                        pauseResponseTcs.TrySetResult(true, asyncAwaitContinuations: true);
    
                    return resumeTask;
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
    
    
        }
    
        public static class TaskExt
        {
            class SimpleSynchronizationContext : SynchronizationContext
            {
                internal static readonly SimpleSynchronizationContext Instance = new SimpleSynchronizationContext();
            };
    
            public static void TrySetResult<TResult>(this TaskCompletionSource<TResult> @this, TResult result, bool asyncAwaitContinuations)
            {
                if (!asyncAwaitContinuations)
                {
                    @this.TrySetResult(result);
                    return;
                }
    
                var sc = SynchronizationContext.Current;
                SynchronizationContext.SetSynchronizationContext(SimpleSynchronizationContext.Instance);
                try
                {
                    @this.TrySetResult(result);
                }
                finally
                {
                    SynchronizationContext.SetSynchronizationContext(sc);
                }
            }
        }
    }
