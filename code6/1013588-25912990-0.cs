    var task = Task.WhenAll(a, b);
    try
    {
        await task;
    }
    catch
    {
        Trace.WriteLine(string.Join(", ", task.Exception.Flatten().InnerExceptions.Select(e => e.Message)));
    }
