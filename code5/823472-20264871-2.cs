    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
    	public class HighPrecisionTimer
    	{
    		Task _task;
    		CancellationTokenSource _cancelSource;
    
    		public void Start()
    		{
    			_cancelSource = new CancellationTokenSource();
    
    			Task<Task> task = Task.Factory.StartNew(
    				function: ExecuteAsync, 
    				cancellationToken: _cancelSource.Token, 
    				creationOptions: TaskCreationOptions.LongRunning, 
    				scheduler: TaskScheduler.Default);
    
    			_task = task.Unwrap();
    		}
    
    		public void Stop()
    		{
    			_cancelSource.Cancel(); // request the cancellation
    
    			_task.Wait(); // wait for the task to complete
    		}
    
    		async Task ExecuteAsync()
    		{
    			Console.WriteLine("Enter ExecuteAsync");
    			while (!_cancelSource.IsCancellationRequested)
    			{
    				await Task.Delay(42); // for testing
    
    				// DO CUSTOM TIMER STUFF...
    			}
    			Console.WriteLine("Exit ExecuteAsync");
    		}
    	}
    
    	class Program
    	{
    		public static void Main()
    		{
    			var highPrecisionTimer = new HighPrecisionTimer();
    
    			Console.WriteLine("Start timer");
    			highPrecisionTimer.Start();
    			
    			Thread.Sleep(2000);
    			
    			Console.WriteLine("Stop timer");
    			highPrecisionTimer.Stop();
    			
    			Console.WriteLine("Press Enter to exit...");
    			Console.ReadLine();
    		}
    	}
    }
