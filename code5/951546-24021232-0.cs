    // ContinueWith([NotNull] Action<Task> continuationAction)
    // WriteLine([NotNull] string format, object arg0)
    .ContinueWith(t => Console.WriteLine("Should not be executed. Task status = " + t.Status, TaskContinuationOptions.NotOnCanceled));
    // ContinueWith([NotNull] Action<Task> continuationAction, TaskContinuationOptions continuationOptions)
    // WriteLine(string value) 
    .ContinueWith(t => Console.WriteLine("Should not be executed. Task status = " + t.Status), TaskContinuationOptions.NotOnCanceled);
