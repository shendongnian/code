    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
    	public class Program
    	{
    		// .NET 4.5/C# 5.0: convert EAP pattern into TAP pattern with timeout
    		public async Task<AsyncCompletedEventArgs> BlackBoxOperationAsync(
    			object state,
    			CancellationToken token,
    			int timeout = Timeout.Infinite)
    		{
    			var tcs = new TaskCompletionSource<AsyncCompletedEventArgs>();
    			using (var cts = CancellationTokenSource.CreateLinkedTokenSource(token))
    			{
    				// prepare the timeout
    				if (timeout != Timeout.Infinite)
    				{
    					cts.CancelAfter(timeout);
    				}
    
    				// handle completion
    				AsyncCompletedEventHandler handler = (sender, args) =>
    				{
    					if (args.Cancelled)
    						tcs.TrySetCanceled();
    					else if (args.Error != null)
    						tcs.SetException(args.Error);
    					else
    						tcs.SetResult(args);
    				};
    
    				this.BlackBoxOperationCompleted += handler;
    				try
    				{
    					using (cts.Token.Register(() => tcs.SetCanceled(), useSynchronizationContext: false))
    					{
    						this.StartBlackBoxOperation(null);
    						return await tcs.Task.ConfigureAwait(continueOnCapturedContext: false);
    					}
    				}
    				finally
    				{
    					this.BlackBoxOperationCompleted -= handler;
    				}
    			}
    		}
    
    		// emulate async operation
    		AsyncCompletedEventHandler BlackBoxOperationCompleted = delegate { };
    
    		void StartBlackBoxOperation(object state)
    		{
    			ThreadPool.QueueUserWorkItem(s =>
    			{
    				Thread.Sleep(1000);
    				this.BlackBoxOperationCompleted(this, new AsyncCompletedEventArgs(error: null, cancelled: false, userState: state));
    			}, state);
    		}
    
    		// test
    		static void Main()
    		{
    			try
    			{
    				new Program().BlackBoxOperationAsync(null, CancellationToken.None, 1200).Wait();
    				Console.WriteLine("Completed.");
    				new Program().BlackBoxOperationAsync(null, CancellationToken.None, 900).Wait();
    			}
    			catch (Exception ex)
    			{
    				while (ex is AggregateException)
    					ex = ex.InnerException;
    				Console.WriteLine(ex.Message);
    			}
    			Console.ReadLine();
    		}
    	}
    }
