    public async Task DoMultipleWork() {
    var uploadTask = UploadAsync(file);
    var processingTask = Task.Run( () => DoCpuWork() );
    
    uploadTask.ContinueWith((Task t) => Console.WriteLine("YOUR_MESSAGE"), TaskContinuationOptions.OnlyOnRanToCompletion);
    processingTask.ContinueWith((Task t) => Console.WriteLine("YOUR_MESSAGE"),     TaskContinuationOptions.OnlyOnRanToCompletion);
    await Task.WaitAll(new []{uploadTask, processingTask});
    
    }
