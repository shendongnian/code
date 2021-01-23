    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static async Task TestAsync()
            {
                Console.WriteLine("A, threads: {0}, thread: {1}", Process.GetCurrentProcess().Threads.Count, Thread.CurrentThread.ManagedThreadId);
    			await new CustomAwaiter(async: false);
    			Console.WriteLine("B, threads: {0}, thread: {1}", Process.GetCurrentProcess().Threads.Count, Thread.CurrentThread.ManagedThreadId);
    
                Console.WriteLine("C, threads: {0}, thread: {1}", Process.GetCurrentProcess().Threads.Count, Thread.CurrentThread.ManagedThreadId);
                await new CustomAwaiter(async: true);
                Console.WriteLine("D, threads: {0}, thread: {1}", Process.GetCurrentProcess().Threads.Count, Thread.CurrentThread.ManagedThreadId);
            }
    
            static void Main(string[] args)
            {
                TestAsync().Wait();
            }
        }
    
        public struct CustomAwaiter:
            System.Runtime.CompilerServices.INotifyCompletion
        {
            readonly bool _async;
    
    		public CustomAwaiter(bool async = true) { _async = async; }
    
            // awaiter methods
            public CustomAwaiter GetAwaiter() { return this; }
    
            public bool IsCompleted {get { return !_async; } }
    
            public void GetResult() { }
    
            // ICriticalNotifyCompletion
            public void OnCompleted(Action continuation) { continuation(); }
        }
    }
