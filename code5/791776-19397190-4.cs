    using System;
    using System.Collections.Generic;
    using System.Runtime.ExceptionServices;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace MultipleTasks
    {
    	class Program
    	{
    		class Worker
    		{
    			// a single async Task
    			async Task<object> DoTaskAsync(string id, CancellationToken token, int delay)
    			{
    				Console.WriteLine("Task: " + id);
    				await Task.Delay(delay, token); // do some work
    				return id;
    			}
    
    			// DoTaskSequenceAsync depends on Task1, Task2, Task3
    			async Task<object> DoTaskSequenceAsync(string id, CancellationToken token)
    			{
    				Console.WriteLine("Task: " + id);
    				await DoTaskAsync(id + "." + "Task1", token, 1000);
    				await DoTaskAsync(id + "." + "Task2", token, 2000);
    				await DoTaskAsync(id + "." + "Task3", token, 3000);
    				// do more
    				return id;
    			}
    
    			// a bad task which throws 
    			async Task<object> BadTaskAsync(string id, CancellationToken token, int delay)
    			{
    				Console.WriteLine("Task: " + id);
    				await Task.Delay(delay, token);
    				throw new ApplicationException(id);
    			}
    
    			// wraps a task and requests the cancellation if the task has failed 
    			async Task<T> WrapAsync<T>(CancellationTokenSource cts,
    				Func<CancellationToken, Task<T>> taskFactory)
    			{
    				try
    				{
    					return await taskFactory(cts.Token);
    				}
    				catch
    				{
    					if (!cts.IsCancellationRequested)
    					{
    						cts.Cancel(); // cancel the others
    					}
    					throw; // rethrow
    				}
    			}
    
    			// run all tasks
    			public async Task DoWorkAsync(CancellationToken outsideCt)
    			{
    				var tasks = new List<Task<object>>();
    
    				var cts = new CancellationTokenSource();
    
    				ExceptionDispatchInfo capturedException = null;
    
    				try
    				{
    					using (outsideCt.Register(() => cts.Cancel()))
    					{
    						// these tasks run in parallel
    						tasks.Add(WrapAsync(cts, (token) => DoTaskAsync("Task1", token, 500)));
    						tasks.Add(WrapAsync(cts, (token) => DoTaskSequenceAsync("Sequence1", token)));
    						tasks.Add(WrapAsync(cts, (token) => DoTaskAsync("Task2", token, 1000)));
    						tasks.Add(WrapAsync(cts, (token) => BadTaskAsync("BadTask", token, 1200)));
    						tasks.Add(WrapAsync(cts, (token) => DoTaskSequenceAsync("Sequence2", token)));
    						tasks.Add(WrapAsync(cts, (token) => DoTaskAsync("Task3", token, 1500)));
    
    						await Task.WhenAll(tasks.ToArray());
    					}
    				}
    				catch (Exception e)
    				{
    					capturedException = ExceptionDispatchInfo.Capture(e);
    				}
    
    				if (outsideCt.IsCancellationRequested)
    				{
    					Console.WriteLine("Cancelled from outside.");
    					return;
    				}
    
    				if (cts.IsCancellationRequested || capturedException != null)
    				{
    					if (cts.IsCancellationRequested)
    					{
    						Console.WriteLine("Cancelled by a failed task.");
    						// find the failed task in tasks or via capturedException
    					}
    					if (capturedException != null && capturedException.SourceException != null)
    					{
    						Console.WriteLine("Source exception: " + capturedException.SourceException.ToString());
    						// could rethrow the original exception:
    						// capturedException.Throw();					
    					}	
    				}
    
    				Console.WriteLine("Results:");
    				tasks.ForEach((task) =>
    						Console.WriteLine(String.Format("Status: {0}, result: {1}",
    							task.Status.ToString(), 
    							task.Status == TaskStatus.RanToCompletion? task.Result.ToString(): String.Empty)));
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			var cts = new CancellationTokenSource(10000);
    			new Worker().DoWorkAsync(cts.Token).Wait();
    			Console.WriteLine("Done.");
    			Console.ReadLine();
    		}
    	}
    }
