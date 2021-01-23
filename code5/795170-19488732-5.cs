    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication
    {
    	class Program
    	{
    		class Worker
    		{
    			public struct Response
    			{
    				public string message;
    				public int threadId;
    			}
    
    			CancellationToken _token;
    			readonly ConcurrentQueue<string> _messages = new ConcurrentQueue<string>();
    			readonly ConcurrentDictionary<string, TaskCompletionSource<Response>> _requests = new ConcurrentDictionary<string, TaskCompletionSource<Response>>();
    
    			public Worker(CancellationToken token)
    			{
    				_token = token;
    			}
    
    			string ReadNextMessage()
    			{
    				// using Thread.Sleep(100) for test purposes here,
    				// should be using ManualResetEvent (or similar synchronization primitive),
    				// depending on how messages arrive
    				string message;
    				while (!_messages.TryDequeue(out message))
    				{
    					Thread.Sleep(100);
    					_token.ThrowIfCancellationRequested();
    				}
    				return message;
    			}
    
    			public void ReceiverRun()
    			{
    				LogThread("Enter ReceiverRun");
    				while (true)
    				{
    					var msg = ReadNextMessage();
    					LogThread("ReadNextMessage: " + msg);
    					var tcs = _requests[msg];
    					tcs.SetResult(new Response { message = msg, threadId = Thread.CurrentThread.ManagedThreadId });
    					_token.ThrowIfCancellationRequested(); // this is how we terminate the loop
    				}
    			}
    
    			Task<Response> SendAwaitResponse(string msg)
    			{
    				LogThread("SendAwaitResponse: " + msg);
    				var tcs = new TaskCompletionSource<Response>();
    				_requests.TryAdd(msg, tcs);
    				_messages.Enqueue(msg);
    				return tcs.Task;
    			}
    
    			public async Task ProcessAsync()
    			{
    				LogThread("Enter Worker.ProcessAsync");
    
    				var task1 = SendAwaitResponse("first message");
    				await task1;
    				LogThread("result1: " + task1.Result.message);
    				// avoid deadlock for task2.Wait() with Task.Yield()
    				// comment this out and task2.Wait() will dead-lock
    				if (task1.Result.threadId == Thread.CurrentThread.ManagedThreadId)
    					await Task.Yield();
    
    				var task2 = SendAwaitResponse("second message");
    				task2.Wait();
    				LogThread("result2: " + task2.Result.message);
    
    				var task3 = SendAwaitResponse("third message");
    				// still on the same thread as with result 2, no deadlock for task3.Wait()
    				task3.Wait();
    				LogThread("result3: " + task3.Result.message);
    
    				var task4 = SendAwaitResponse("fourth message");
    				await task4;
    				LogThread("result4: " + task4.Result.message);
    				// avoid deadlock for task5.Wait() with Task.Yield()
    				// comment this out and task5.Wait() will dead-lock
    				if (task4.Result.threadId == Thread.CurrentThread.ManagedThreadId)
    					await Task.Yield();
    
    				var task5 = SendAwaitResponse("fifth message");
    				task5.Wait();
    				LogThread("result5: " + task5.Result.message);
    
    				LogThread("Leave Worker.ProcessAsync");
    			}
    
    			public static void LogThread(string message)
    			{
    				Console.WriteLine("{0}, thread: {1}", message, Thread.CurrentThread.ManagedThreadId);
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			Worker.LogThread("Enter Main");
    			var cts = new CancellationTokenSource(5000); // cancel after 5s
    			var worker = new Worker(cts.Token);
    			Task receiver = Task.Run(() => worker.ReceiverRun());
    			Task main = worker.ProcessAsync();
    			try
    			{
    				Task.WaitAll(main, receiver);
    			}
    			catch (Exception e)
    			{
    				Console.WriteLine("Exception: " + e.Message);
    			}
    			Worker.LogThread("Leave Main");
    			Console.ReadLine();
    		}
    	}
    }
