    // by Noseratio - http://stackoverflow.com/users/1768303/noseratio
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ConsoleApplicationWebBrowser
    {
    	class Program
    	{
    		// Entry Point of the console app
    		static void Main(string[] args)
    		{
    			try
    			{
    				// download each page and dump the content
    				var task = MessageLoopWorker.Run(DoWorkAsync,
    					"http://www.example.com", "http://www.example.net", "http://www.example.org");
    				task.Wait();
    				Console.WriteLine("DoWorkAsync completed.");
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine("DoWorkAsync failed: " + ex.Message);
    			}
    			Console.WriteLine("Press Enter to exit.");
    			Console.ReadLine();
    		}
    
    		// navigate WebBrowser to the list of urls in a loop
    		static async Task<object> DoWorkAsync(object[] args)
    		{
    			Console.WriteLine("Start working.");
    
    			var wb = new WebBrowser();
    			wb.ScriptErrorsSuppressed = true;
    
    			if (wb.Document == null && wb.ActiveXInstance == null)
    				throw new ApplicationException("Unable to initialize the underlying WebBrowserActiveX");
    
    			// get the underlying WebBrowser ActiveX object;
    			// this code depends on SHDocVw.dll COM interop assembly,
    			// generate SHDocVw.dll: "tlbimp.exe ieframe.dll",
    			// and add as a reference to the project
    			var wbax = (SHDocVw.WebBrowser)wb.ActiveXInstance;
    
    			TaskCompletionSource<bool> loadedTcs = null;
    			WebBrowserDocumentCompletedEventHandler documentCompletedHandler = (s, e) =>
    				loadedTcs.TrySetResult(true); // turn event into awaitable task
    
    			TaskCompletionSource<bool> printedTcs = null;
    			SHDocVw.DWebBrowserEvents2_PrintTemplateTeardownEventHandler printTemplateTeardownHandler = (p) =>
    				printedTcs.TrySetResult(true); // turn event into awaitable task
    
    			// navigate to each URL in the list
    			foreach (var url in args)
    			{
    				loadedTcs = new TaskCompletionSource<bool>();
    				wb.DocumentCompleted += documentCompletedHandler;
    				try
    				{
    					wb.Navigate(url.ToString());
    					// await for DocumentCompleted
    					await loadedTcs.Task;
    				}
    				finally
    				{
    					wb.DocumentCompleted -= documentCompletedHandler;
    				}
    
    				// the DOM is ready, 
    				Console.WriteLine(url.ToString());
    				Console.WriteLine(wb.Document.Body.OuterHtml);
    
    				// print the document
    				printedTcs = new TaskCompletionSource<bool>();
    				wbax.PrintTemplateTeardown += printTemplateTeardownHandler;
    				try
    				{
    					wb.Print();
    					// await for PrintTemplateTeardown - the end of printing
    					await printedTcs.Task;
    				}
    				finally
    				{
    					wbax.PrintTemplateTeardown -= printTemplateTeardownHandler;
    				}
    				Console.WriteLine(url.ToString() + " printed.");
    			}
    
    			wb.Dispose();
    			Console.WriteLine("End working.");
    			return null;
    		}
    
    	}
    
    	// a helper class to start the message loop and execute an asynchronous task
    	public static class MessageLoopWorker
    	{
    		public static async Task<object> Run(Func<object[], Task<object>> worker, params object[] args)
    		{
    			var tcs = new TaskCompletionSource<object>();
    
    			var thread = new Thread(() =>
    			{
    				EventHandler idleHandler = null;
    
    				idleHandler = async (s, e) =>
    				{
    					// handle Application.Idle just once
    					Application.Idle -= idleHandler;
    
    					// return to the message loop
    					await Task.Yield();
    
    					// and continue asynchronously
    					// propogate the result or exception
    					try
    					{
    						var result = await worker(args);
    						tcs.SetResult(result);
    					}
    					catch (Exception ex)
    					{
    						tcs.SetException(ex);
    					}
    
    					// signal to exit the message loop
    					// Application.Run will exit at this point
    					Application.ExitThread();
    				};
    
    				// handle Application.Idle just once
    				// to make sure we're inside the message loop
    				// and SynchronizationContext has been correctly installed
    				Application.Idle += idleHandler;
    				Application.Run();
    			});
    
    			// set STA model for the new thread
    			thread.SetApartmentState(ApartmentState.STA);
    
    			// start the thread and await for the task
    			thread.Start();
    			try
    			{
    				return await tcs.Task;
    			}
    			finally
    			{
    				thread.Join();
    			}
    		}
    	}
    }
 
