    public async Task DoMultipleWork() 
    {
        var uploadTask = UploadAsync(file);
        var processingTask = Task.Run( () => DoCpuWork() );
        var completedTask = await Task.WhenAny(uploadTask, processingTask);
        Console.WriteLine("upload or processing is done");
        if (completedTask == uploadTask)
        {
            // Upload completed
        }
        else
        {
            // Processing completed
        }
        
        await Task.WhenAll(uploadTask, processingTask) // Make sure both complete
        Console.WriteLine("upload and processing is done");
    }
