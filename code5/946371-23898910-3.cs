    var results = data.Select(item =>
    {
        try
        {
            DoWork(item);
            return null; // no error
        }
        catch (Exception e)
        {
            return e;
        }
    }).Where(e => e != null).ToList();
    
    var errorList = results.Wait();
    // or var errorList = await results;
    // or Task<List<Exception>> errorListTask = results.ToTask();
