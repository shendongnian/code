    public static TResult UseService<TChannel, TResult>(string url,
                                                        EndpointIdentity identity,
                                                        NetworkCredential credential,
                                                        Func<TChannel, TResult> acc)
    {
        var binding = new BasicHttpBinding();
        binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
        binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
        var endPointAddress = new EndpointAddress(new Uri(url), identity,
                                                  new AddressHeaderCollection());
        var factory = new ChannelFactory<T>(binding, address);
        var loginCredentials = new ClientCredentials();
        loginCredentials.Windows.ClientCredential = credentials;
        foreach (var cred in factory.Endpoint.EndpointBehaviors.Where(b => b is ClientCredentials).ToArray())
            factory.Endpoint.EndpointBehaviors.Remove(cred);
        factory.Endpoint.EndpointBehaviors.Add(loginCredentials);
        TChannel channel = factory.CreateChannel();
        bool error = true;
        try
        {
            TResult result = acc(channel);
            ((IClientChannel)channel).Close();
            error = false;
            factory.Close();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return default(TResult);
        }
        finally
        {
            if (error)
                ((IClientChannel)channel).Abort();
        }
    }
