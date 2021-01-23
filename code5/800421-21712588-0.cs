    // We want:
    /*
    Before pause requested
    Before await pause.WaitWhilePausedAsync()
    After pause requested.
    After await pause.WaitWhilePausedAsync()
    */
    
    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		// http://stackoverflow.com/a/19616899/1768303
    		// Based on http://blogs.msdn.com/b/pfxteam/archive/2013/01/13/cooperatively-pausing-async-methods.aspx
    
    		public class PauseTokenSource
    		{
    			private readonly object m_lockObject = new Object();
    			bool m_paused = false; // could use m_resumeRequest as flag too
    
    			internal static readonly Task s_completedTask = Task.FromResult(true);
    			private TaskCompletionSource<bool> m_pauseResponse;
    			private TaskCompletionSource<bool> m_resumeRequest;
    
    			public void Pause()
    			{
    				lock (m_lockObject)
    				{
    					if (m_paused)
    						return;
    					m_paused = true;
    					m_pauseResponse = null;
    					m_resumeRequest = new TaskCompletionSource<bool>();
    				}
    			}
    
    			public void Resume()
    			{
    				TaskCompletionSource<bool> resumeRequest = null;
    
    				lock (m_lockObject)
    				{
    					if (!m_paused)
    						return;
    					m_paused = false;
    					resumeRequest = m_resumeRequest;
    					m_resumeRequest = null;
    				}
    
    				resumeRequest.TrySetResult(true);
    			}
    
    			public Task WaitWhilePausedAsync()
    			{
    				lock (m_lockObject)
    				{
    					if (!m_paused)
    						return s_completedTask;
    					return m_resumeRequest.Task;
    				}
    			}
    
    			// pause with feedback
    			// that the producer task has reached the paused state
    
    			public Task PauseWithResponseAsync()
    			{
    				Task responseTask = null;
    
    				lock (m_lockObject)
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
    
    			public Task WaitWhilePausedWithResponseAsyc()
    			{
    				Task resumeTask = null;
    				TaskCompletionSource<bool> response = null;
    
    				lock (m_lockObject)
    				{
    					if (!m_paused)
    						return s_completedTask;
    					response = m_pauseResponse;
    					resumeTask = m_resumeRequest.Task;
    				}
    
    				response.TrySetResult(true);
    				return resumeTask;
    			}
    
    			public bool IsPaused
    			{
    				get
    				{
    					lock (m_lockObject)
    						return m_paused;
    				}
    			}
    
    			public PauseToken Token { get { return new PauseToken(this); } }
    		}
    
    		public struct PauseToken
    		{
    			private readonly PauseTokenSource m_source;
    			public PauseToken(PauseTokenSource source) { m_source = source; }
    
    			public bool IsPaused { get { return m_source != null && m_source.IsPaused; } }
    
    			public Task WaitWhilePausedAsync()
    			{
    				return IsPaused ?
    						m_source.WaitWhilePausedAsync() :
    						PauseTokenSource.s_completedTask;
    			}
    
    			public Task WaitWhilePausedWithResponseAsyc()
    			{
    				return IsPaused ?
    						m_source.WaitWhilePausedWithResponseAsyc() :
    						PauseTokenSource.s_completedTask;
    			}
    		}
    
    		static void Main()
    		{
    			var pts = new PauseTokenSource();
    			var task = SomeMethodAsync(pts.Token);
    
    			Task.Run(() =>
    			{
    				Console.WriteLine("Before pause requested");
    				pts.PauseWithResponseAsync().Wait();
    				Console.WriteLine("After pause requested.");
    				pts.Resume();
    			}).Wait();
    			Console.ReadLine();
    
    			// Alternatively, async version:
    			/*
    			Func<Task> func = async () =>
    			{
    					Console.WriteLine("Before pause requested");
    					await pts.PauseWithResponseAsync();
    					Console.WriteLine("After pause requested.");
    					pts.Resume();
    			};
    			func().Wait();
    			Console.ReadLine();
    			*/
    		}
    
    		public static async Task SomeMethodAsync(PauseToken pause)
    		{
    			await Task.Delay(500);
    			Console.WriteLine("Before await pause.WaitWhilePausedAsync()");
    			await pause.WaitWhilePausedWithResponseAsyc();
    			Console.WriteLine("After await pause.WaitWhilePausedAsync()");
    		}
    	}
    }
