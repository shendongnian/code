    private async Task UploadAsync(string filepath)
    {
      var result = await fileManager.UploadAsync(filepath);
      Console.WriteLine($"Result from uploading file {result}");
    }
    private async Task ProcessAsync(string filepath, IProgress<T> progress)
    {
      await Task.Run(() => wordProcessor.Process(filepath, progress));
      Console.WriteLine("processing completed");
    }
    ...
    await Task.WhenAll(UploadAsync(filepath), ProcessAsync(filepath, processingProgress));
