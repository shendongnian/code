    namespace Test
    {
    	using System;
    	using System.Collections.Generic;
    	using System.ComponentModel;
    	using System.Diagnostics;
    	using System.Threading;
    
    	public static class MainClass
    	{
    		public static Random sleeper = new Random ();
    
    		public static void Main (string[] args)
    		{
    			Stopwatch timer = new Stopwatch ();
    			List<WorkerClass> workload = new List<WorkerClass> ();
    
    			// Create a workload of 5000 objects
    			for (int i = 0; i < 5000; i++) {
    				workload.Add (new WorkerClass ());
    			}
    
    			int fires = 0;
    			// Start processing the workload
    			while (true) {
    				// We'll measure the time it took to go through the entire workload
    				// to illustrate that it does not take all that long.
    				timer.Restart ();
    				foreach (WorkerClass w in workload) {
    					// for each of the worker objects in the entire workload
    					// we decrease its internal counter by 1.
    					// Because after the loop is done, we sleep for 1 secondd
    					// that amounts to reducing the counter by 1 every second.
    					w.counter--;
    					if (w.counter == 0) {
    						fires++;
    						// Once the counter hits 0, do the work.
    						w.DoWork ();
    					}
    				}
    				timer.Stop ();
    				Console.WriteLine ("Processing the entire workload of {0} objects took {1} milliseconds, {2} workers actually fired.", workload.Count, timer.ElapsedMilliseconds, fires);
    				fires = 0;
    				Thread.Sleep (1000);
    			}
    		}
    	}
    
    	public class WorkerClass
    	{
    		public int counter = 0;
    
    		public WorkerClass ()
    		{
    			// When the worker is created, set its internal counter
    			// to a random value between 5 and 10.
    			// This is to mimic sleeping it for a random interval.
    			// Also see the primary loop in MainClass.Main
    			this.counter = MainClass.sleeper.Next (5, 10);
    		}
    
    		public void DoWork ()
    		{
    			// Whenever we do the work, we'll create a background worker thread
    			// that actually does the work.
    			BackgroundWorker work = new BackgroundWorker ();
    			work.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) => {
    				// This simulates going back to sleep for a random interval, see
    				// the main loop in MainClass.Main
    				this.counter = MainClass.sleeper.Next (5, 10);
    			};
    			work.DoWork += (object sender, DoWorkEventArgs e) => {
    				// Simulate working by sleeping a random interval
    				Thread.Sleep (MainClass.sleeper.Next (2000, 5000));
    			};
    			// And now we actually do the work.
    			work.RunWorkerAsync ();
    		}
    	}
    }
