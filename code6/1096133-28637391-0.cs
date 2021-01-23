    var client = _smtpClientPool.Get();
    try
    {
        await client.SendMailAsync(...)
    }
    finally
    {
        client.Put(client);
    }
