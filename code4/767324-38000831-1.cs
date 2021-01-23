    class Ref<T>
    {
        // Field rather than a property to support passing to functions
        // accepting `ref T` or `out T`.
        public T Value;
    }
    
    async Task OperationExampleAsync(Ref<int> successfulLoopsRef)
    {
        var things = new[] { 0, 1, 2, };
        var i = 0;
        while (true)
        {
            // Fourth iteration will throw an exception, but we will still have
            // communicated data back to the caller via successfulLoopsRef.
            things[i] += i;
            successfulLoopsRef.Value++;
            i++;
        }
    }
    
    async Task UsageExample()
    {
        var successCounterRef = new Ref<int>();
        // Note that it does not make sense to access successCounterRef
        // until OperationExampleAsync completes (either fails or succeeds)
        // because there’s no synchronization. Here, I think of passing
        // the variable as “temporarily giving ownership” of the referenced
        // object to OperationExampleAsync. Deciding on conventions is up to
        // you and belongs in documentation ^^.
        try
        {
            await OperationExampleAsync(successCounterRef);
        }
        finally
        {
            Console.WriteLine($"Had {successCounterRef.Value} successful loops.");
        }
    }
