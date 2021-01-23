    public Task<MyDomainModel> GetHomeInfoAsync(DateTime timestamp)
    {
        using (var helper = new ServiceHelper<ServiceClient, ServiceContract>())
        {
            return helper.Proxy.GetHomeInfoAsync(timestamp).ContinueWith(antecedent=>processReplay(antecedent.Result));
        }
    }
