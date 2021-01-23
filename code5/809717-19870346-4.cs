    try
    {
        await Task.Run(async () =>
                            {
                                await Task.Delay(5000);
                                throw new Exception("Test1");
                            });
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
