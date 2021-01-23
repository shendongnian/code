    var client = _smtpClientPool.Get();
    try
    {
        await client.SendMailAsync(...)
    }
    finally
    {
        _smtpClientPool.Put(client);
    }
