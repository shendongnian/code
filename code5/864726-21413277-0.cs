    interface IProxyActionCallback
    {
        void DoProxyStuff(ServiceClient proxy);
    }
    void MyMethod(IProxyActionCallback callback)
    {
        try
        {
            ServiceClient proxy = new ServiceClient();
            proxy.ClientCredentials.UserName.UserName = "user";
            proxy.ClientCredentials.UserName.Password = "password";
            callback.DoProxyStuff(proxy);
            proxy.Close();
        }
        catch (FaultException ex)
        {
            // handle the exception      
        }
    }
