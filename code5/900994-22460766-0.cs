    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace BGWorkerConsoleApp
    {
    	class Program
    	{
    		static Stopwatch sw = new Stopwatch();
    		static void Main(string[] args)
    		{
    			// parse your args
    			int[] parsedargs = { 1400, 1000, 500 };
    			int count = 0; // to provide task count
    			List<Task> tasks = new List<Task>();
    			sw.Start(); //stopwatch for some to verify the time
    			foreach (int i in parsedargs)
    			{
    				// start a task for each
    				tasks.Add(Task.Factory.StartNew<bool>(
    					() => { return myTask(i, String.Format("Task{0} done.  ", ++count)); } ) );
    			}
    
    			// wait for all the tasks to complete
    			Task.WaitAll(tasks.ToArray());
    
    			// check the response of each
    			bool faulted = false;
    			foreach (Task<bool> t in tasks)
    			{
    				if (t.Result == false)
    				{
    					faulted = true;
    					break; //there was a problem so quit looking
    				}
    			}
    
    			//output some text
    			if (faulted)
    			{
    				Console.WriteLine("There was a problem.");
    			}
    			else
    				Console.WriteLine("complete");
    
    			// pause so we can see our output in the debugger
    			Console.ReadKey();
    		}
    
    		static bool myTask(int time, string msg)
    		{
    			Thread.Sleep(time);
    			if (time == 1000)
    				return false; 
    			Console.WriteLine(msg + printStopWatchTime());
    			return true;
    		}
    
    		static string printStopWatchTime()
    		{
    			TimeSpan ts = sw.Elapsed;
    			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    			ts.Hours, ts.Minutes, ts.Seconds,
    			ts.Milliseconds / 10);
    			return string.Format("RunTime {0}", elapsedTime);
    		}
    	}
    } 
