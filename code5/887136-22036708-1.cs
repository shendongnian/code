    int numTasks = 20;
    SemaphoreSlim semaphore = new SemaphoreSlim(numTasks);
    HttpClient client = new HttpClient();
                        
    List<string> result = new List<string>();
    foreach(var url in urls)
    {
        semaphore.Wait();
        client.GetStringAsync(url)
              .ContinueWith(t => {
                  lock (result) result.Add(t.Result);
                  semaphore.Release();
              });
    }
    for (int i = 0; i < numTasks; i++) semaphore.Wait();
