    public async Task SynchronizeAsync()
    {
        var gch = GCHandle.Alloc(tcs);
        try
        {
            await tcs.Task;
        }
        finally
        {
            gch.Free();
        }
    }
