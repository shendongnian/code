    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		static readonly string CorrelationManagerSlot = "System.Diagnostics.Trace.CorrelationManagerSlot";
    
    		public static void ShowCorrelationManagerStack(object where)
    		{
    			object top = "null";
    			var stack = (MyStack)CallContext.LogicalGetData(CorrelationManagerSlot);
    			if (stack.Count > 0)
    				top = stack.Peek();
    
    			Console.WriteLine("{0}: MyStack Id={1}, Count={2}, on thread {3}, top: {4}",
    				where, stack.Id, stack.Count, Environment.CurrentManagedThreadId, top);
    		}
    
    		private static void Main()
    		{
    			CallContext.LogicalSetData(CorrelationManagerSlot, new MyStack());
    
    			OuterOperationAsync().Wait();
    			Console.ReadLine();
    		}
    
    		private static async Task OuterOperationAsync()
    		{
    			ShowCorrelationManagerStack(1.1);
    
    			using (LogicalFlow.StartScope())
    			{
    				ShowCorrelationManagerStack(1.2);
    				Console.WriteLine("\t" + LogicalFlow.CurrentOperationId);
    				await InnerOperationAsync();
    				ShowCorrelationManagerStack(1.3);
    				Console.WriteLine("\t" + LogicalFlow.CurrentOperationId);
    				await InnerOperationAsync();
    				ShowCorrelationManagerStack(1.4);
    				Console.WriteLine("\t" + LogicalFlow.CurrentOperationId);
    			}
    
    			ShowCorrelationManagerStack(1.5);
    		}
    
    		private static async Task InnerOperationAsync()
    		{
    			ShowCorrelationManagerStack(2.1);
    			using (LogicalFlow.StartScope())
    			{
    				ShowCorrelationManagerStack(2.2);
    				await Task.Delay(100);
    				ShowCorrelationManagerStack(2.3);
    			}
    			ShowCorrelationManagerStack(2.4);
    		}
    	}
    
    	public class MyStack : Stack, ICloneable
    	{
    		public static int s_Id = 0;
    
    		public int Id { get; private set; }
    
    		object ICloneable.Clone()
    		{
    			var cloneId = Interlocked.Increment(ref s_Id); ;
    			Console.WriteLine("Cloning MyStack Id={0} into {1} on thread {2}", this.Id, cloneId, Environment.CurrentManagedThreadId);
    
    			var clone = new MyStack();
    			clone.Id = cloneId;
    
    			foreach (var item in this.ToArray().Reverse())
    				clone.Push(item);
    
    			return clone;
    		}
    	}
    
    	public static class LogicalFlow
    	{
    		public static Guid CurrentOperationId
    		{
    			get
    			{
    				return Trace.CorrelationManager.LogicalOperationStack.Count > 0
    					? (Guid)Trace.CorrelationManager.LogicalOperationStack.Peek()
    					: Guid.Empty;
    			}
    		}
    
    		public static IDisposable StartScope()
    		{
    			Program.ShowCorrelationManagerStack("Before StartLogicalOperation");
    			Trace.CorrelationManager.StartLogicalOperation();
    			Program.ShowCorrelationManagerStack("After StartLogicalOperation");
    			return new Stopper();
    		}
    
    		private static void StopScope()
    		{
    			Program.ShowCorrelationManagerStack("Before StopLogicalOperation");
    			Trace.CorrelationManager.StopLogicalOperation();
    			Program.ShowCorrelationManagerStack("After StopLogicalOperation");
    		}
    
    		private class Stopper : IDisposable
    		{
    			private bool _isDisposed;
    			public void Dispose()
    			{
    				if (!_isDisposed)
    				{
    					StopScope();
    					_isDisposed = true;
    				}
    			}
    		}
    	}
    }
