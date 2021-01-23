    // We want:
    /*
    Before pause requested
    Before await pause.WaitWhilePausedAsync()
    After pause requested, paused: True
    Press enter to resume...
    
    After await pause.WaitWhilePausedAsync()
     */
    
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        class Program
        {
            // http://stackoverflow.com/a/19616899/1768303
            // Based on http://blogs.msdn.com/b/pfxteam/archive/2013/01/13/cooperatively-pausing-async-methods.aspx
    
            public class PauseTokenSource
            {
                readonly object m_lock = new Object();
                bool m_paused = false;
    
                internal static readonly Task s_completedTask = Task.FromResult(false);
                TaskCompletionSource<bool> m_pauseResponse;
                TaskCompletionSource<bool> m_resumeRequest;
    
                public PauseToken Token { get { return new PauseToken(this); } }
    
                public bool IsPaused
                {
                    get
                    {
                        lock (m_lock)
                            return m_paused;
                    }
                }
    
                // pause without feedback
                public void Pause()
                {
                    lock (m_lock)
                    {
                        if (m_paused)
                            return;
                        m_paused = true;
                        m_pauseResponse = null;
                        m_resumeRequest = new TaskCompletionSource<bool>();
                    }
                }
    
                // pause with feedback
                public Task PauseWithResponseAsync()
                {
                    Task responseTask = null;
    
                    lock (m_lock)
                    {
                        if (m_paused)
                            return m_pauseResponse.Task;
                        m_paused = true;
                        m_pauseResponse = new TaskCompletionSource<bool>();
                        m_resumeRequest = new TaskCompletionSource<bool>();
                        responseTask = m_pauseResponse.Task;
                    }
    
                    return responseTask;
                }
    
                // resume
                public void Resume()
                {
                    TaskCompletionSource<bool> resumeRequest = null;
    
                    lock (m_lock)
                    {
                        if (!m_paused)
                            return;
                        m_paused = false;
                        resumeRequest = m_resumeRequest;
                        m_resumeRequest = null;
                    }
    
                    if (resumeRequest != null)
                        resumeRequest.TrySetResult(true);
                }
     
                internal Task WaitWhilePausedWithResponseAsyc()
                {
                    Task resumeTask = s_completedTask;
                    TaskCompletionSource<bool> response = null;
    
                    lock (m_lock)
                    {
                        if (!m_paused)
                            return s_completedTask;
                        response = m_pauseResponse;
                        resumeTask = m_resumeRequest.Task;
                    }
    
                    if (response != null)
                        Reply(() => response.TrySetResult(true));
    
                    return resumeTask;
                }
    
                static void Reply(Action action)
                {
                    SynchronizationContext context = SynchronizationContext.Current;
                    if (context == null)
                        ThreadPool.QueueUserWorkItem((a) => ((Action)a)(), action);
                    else
                        context.Post((a) => ((Action)a)(), action);
                }
            }
    
            public struct PauseToken
            {
                readonly PauseTokenSource m_source;
    
                public PauseToken(PauseTokenSource source) { m_source = source; }
    
                public bool IsPaused { get { return m_source != null && m_source.IsPaused; } }
    
                public Task WaitWhilePausedWithResponseAsyc()
                {
                    return IsPaused ?
                            m_source.WaitWhilePausedWithResponseAsyc() :
                            PauseTokenSource.s_completedTask;
                }
            }
    
            // Testing
    
            static async Task Test()
            {
                var pts = new PauseTokenSource();
                var task = SomeMethodAsync(pts.Token);
    
                Console.WriteLine("Press enter to pause...");
                Console.ReadLine();
    
                // sync version
                Console.WriteLine("Before pause requested");
                pts.PauseWithResponseAsync().Wait();
                Console.WriteLine("After pause requested, paused: " + pts.Token.IsPaused);
                Console.WriteLine("Press enter to resume...");
                Console.ReadLine();
                pts.Resume();
    
                // async version:
                Console.WriteLine("Before pause requested");
                await pts.PauseWithResponseAsync();
                Console.WriteLine("After pause requested, paused: " + pts.Token.IsPaused);
                Console.WriteLine("Press enter to resume...");
                Console.ReadLine();
                pts.Resume();
    
                // async pause request: pts.Pause();
                Console.WriteLine("Press enter to pause...");
                Console.ReadLine();
                Console.WriteLine("Before pause requested");
                pts.Pause();
    
                Console.WriteLine("After pause requested, paused: " + pts.Token.IsPaused);
                Console.WriteLine("Press enter to resume after the task has confirmed paused...");
                Console.ReadLine();
                Console.WriteLine("Paused: " + pts.Token.IsPaused);
                pts.Resume();
            }
    
            static void Main()
            {
                Test().Wait();
                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }
    
            public static async Task SomeMethodAsync(PauseToken pause)
            {
                try
                {
                    while (true)
                    {
                        await Task.Delay(1000).ConfigureAwait(false);
                        Console.WriteLine("Before await pause.WaitWhilePausedAsync()");
                        await pause.WaitWhilePausedWithResponseAsyc();
                        Console.WriteLine("After await pause.WaitWhilePausedAsync()");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e);
                    throw;
                }
            }
        }
    }
