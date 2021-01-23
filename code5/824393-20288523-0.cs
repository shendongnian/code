    var tasks = new List<Task>();
    foreach (Uri uri in uris)
    {
        var thisTask = Task.Run(() => 
                           { 
                             httpClient.GetStringAsync(uri).ConfigureAwait(false);
                             var processedData = dataProcessor.Process(rawData);
                             processedDataCollection.Add(processedData);
                           });
        tasks.Add(thisTask);
    }
    Task.WaitAll(tasks);
