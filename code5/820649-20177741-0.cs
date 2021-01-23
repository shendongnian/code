    public static IPAddress GetADefaultGateway()
    {
        foreach (var card = NetworkInterface.GetAllNetworkInterfaces())
        {
           if (card == null)
           {
             continue;
           }
           foreach (var address = card.GetIPProperties().GatewayAddresses)
           {
             if (address == null)
             {
               continue;
             }
             //We've found one
             return address.Address;
           }
        }
        //We didn't find any
        return null;
    }
