using (CancellationTokenSource cancelAfterDelay = new CancellationTokenSource(TimeSpan.FromSeconds(timeout)))
{
    DateTime startedTime = DateTime.Now;
    try
    {
        response = await request.ExecuteAsync(cancelAfterDelay.Token);
    }
    catch (TaskCanceledException e)
    {
        DateTime cancelledTime = DateTime.Now;
        if (startedTime.AddSeconds(timeout-1) <= cancelledTime)
        {
            throw new TimeoutException($"An HTTP request to {request.Url} timed out ({timeout} seconds)");
        }
        else
            throw;
    }
}
return response;
