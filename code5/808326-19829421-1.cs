    public interface IClientInstance
    {
    }
    public static class ClientInstance
    {
        public enum ClientTypes
        {
            ClientTypeA,
            ClientTypeB
        };
    public static ClientInstance Create(ClientTypes ofClientType)
    {
        IClientInstance clientObject = null;
        switch (ofClientType)
        {
            case ClientInstance.ClientTypes.ClientTypeA:
                clientObject = new ClientClassA() as ClientInstance;
            default:
                break;
        }
        return clientObject;
    }
    }
