    class Program {
        // Need to change the declaration of Main() in order to use 'await'
        static async Task Main () {
            // Create a custom awaitable object
            MyAwaitable awaitable = new MyAwaitable ();
            // Run awaitable payload, ignore returned Task
            _ = awaitable.Run ();
            // Do some other tasks while awaitable is running
            Console.WriteLine ("Waiting for completion...");
            // Wait for completion
            await awaitable;
            Console.WriteLine ("The long operation is now complete. " + awaitable.GetResult());
        }
    }
    public class MyAwaitable : INotifyCompletion {
        // Fields
        private Action continuation = null;
        private string result = string.Empty;
        // Make this class awaitable
        public MyAwaitable GetAwaiter () { return this; }
        // Implementation of INotifyCompletion for the self-awaiter
        public bool IsCompleted { get; set; }
        public string GetResult () { return result; }
        public void OnCompleted (Action continuation) {
            // Store continuation delegate
            this.continuation = continuation;
            Console.WriteLine ("Continuation set");
        }
        // Payload to run
        public async Task Run () {
            Console.WriteLine ("Computing result...");
            
            // Wait 2 seconds
            await Task.Delay (2000);
            result = "The result is 10";
            // Set completed
            IsCompleted = true;
            Console.WriteLine ("Result available");
            // Continue with the continuation provided
            continuation?.Invoke ();
        }
    }
