    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace GCTesting
    {
    	class Program
    	{
    		static int fragLOHbyIncrementing = 1000;
    		static void Main()
    		{
    			var allDone = new ManualResetEvent(false);
    			int completed = 0;
    			long sum = 0; //just to prevent optimizer to remove cycle etc.
    			const int count = 2000;
    			for (int i = 0; i < count; i++)
    			{
    				ThreadPool.QueueUserWorkItem(delegate
    				{
    					unchecked
    					{
    						var dumb = new Dumb( fragLOHbyIncrementing++ );
    						var localSum = 0;
    						foreach (int x in dumb.Arr)
    						{
    							localSum += x;
    						}
    						sum += localSum;
    					}
    					if (Interlocked.Increment(ref completed) == count)
    						allDone.Set();
    					if (completed % (count / 100) == 0)
    						Console.WriteLine("Progress = {0:N2}%", 100.0 * completed / count);
    				});
    			}
    			allDone.WaitOne();
    			Console.WriteLine("Done. Result : {0}", sum);
    			Console.ReadKey();
    			GC.Collect();
    			Console.WriteLine("GC Collected!");
    			Console.WriteLine("GC CollectionsCount 0 = {0}, 1 = {1}, 2 = {2}", GC.CollectionCount(0), GC.CollectionCount(1), GC.CollectionCount(2));
    			Console.ReadKey();
    		}
    	}
    
    	class Dumb
    	{
    		public Dumb(int incr)
    		{
    			try
    			{
    				DumbAllocation(incr);
    			} 
    			catch (OutOfMemoryException)
    			{
    				Console.WriteLine("Out of memory, trying to compact the LOH.");
    				
    				GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
    				GC.Collect();
    				
    				try // try again
    				{
    					DumbAllocation(incr); 
    					Console.WriteLine("compacting the LOH worked to free up memory.");
    				}
    				catch (OutOfMemoryException)
    				{
    					Console.WriteLine("compaction of LOH failed to free memory.");
    					throw;
    				}
    			}
    		}
    
    		private void DumbAllocation(int incr)
    		{
    			Arr = Enumerable.Range(1, (10 * 1024 * 1024) + incr).ToArray();
    		}
    
    		public int[] Arr;
    	}
    }
