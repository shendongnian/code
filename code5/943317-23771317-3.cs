    const int MAX_PARALLEL = 1000;
    SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(MAX_PARALLEL);
    volatile int _activeClients = 0;
    readonly object _lock = new Object();
    ExternalServiceClient _externalpServiceClient = null;
    ExternalServiceClient GetClient()
    {
        lock (_lock)
        {
            if (_activeClients == 0)
                _externalpServiceClient = new ExternalServiceClient("WSHttpBinding_IExternalService");
            _activeClients++;
            return _externalpServiceClient;
        }
    }
    void ReleaseClient()
    {
        lock (_lock)
        {
            _activeClients--;
            if (_activeClients == 0)
            {
                _externalpServiceClient.Close();
                _externalpServiceClient = null;
            }
        }
    }
    private async Task<string> GetTokenIdForCarsAsync(Car[] cars)
    {
        var client = GetClient();
        try 
        {
            await _semaphoreSlim.WaitAsync().ConfigureAwait(false);
            try
            {
                string tokenId = await client.GetInfoForCarsAsync(cars).ConfigureAwait(false);
                return tokenId;
            }
            catch (Exception ex)
            {
                //TODO plug in log 4 net 
                throw new Exception("Failed" + ex.Message, ex);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
        finally
        {
            ReleaseClient();
        }
    }
