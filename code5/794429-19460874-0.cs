    Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
    Debug.WriteLine("Completed? {0}", getStringTask.IsCompleted); // Will likely print false
    DoIndependentWork();
    string urlContents = await getStringTask;
    Debug.WriteLine("Completed now? {0}", getStringTask.IsCompleted); // Will always print true
