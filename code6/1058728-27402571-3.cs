    var attempts = 0;
    try
    {
        var response = Observable
            .FromAsync(() =>
            {
                attempts++;
                return SendRequest(token);
            })
            .Retry(5)
            .Wait();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
