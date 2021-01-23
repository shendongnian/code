    public class NetworkInformation
    {
    private static Dictionary<string,string> _listOfIPs = null;
    private static Dictionary<string,string> _listOfSubnets = null;
    private static Dictionary<string,string> _listOfGateways = null;
    private static List<Dictionary<string,string>> _myList = new List<Dictionary<string,string>>();
    public static object GetAllNetworkInfo()
    {
        if ( _listOfIPs == null || _listOfSubnets == null || _listofGateways == null ) {
            _listOfIPs = new List<string>();
            _listOfSubnets = new List<string>();
            _listOfGateways = new List<string>();
         } else {
             _listOfIPs.Clear();
             _listOfSubnets.Clear();
             _listOfGateways.Clear();
         }
        NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface networkInterface in networkInterfaces)
        {
            IPInterfaceProperties adapterProperties = networkInterface.GetIPProperties();
            GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
            if (networkInterface.OperationalStatus == OperationalStatus.Up)
            {
                UnicastIPAddressInformationCollection unicastIPC = networkInterface.GetIPProperties().UnicastAddresses;
                foreach (UnicastIPAddressInformation unicast in unicastIPC)
                {
                    if (unicast.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        _listOfIPs.Add(networkInterface.Name, unicast.Address.ToString());
                        _listOfSubnets.Add(networkInterface.Name, unicast.IPv4Mask.ToString());
                    }
                    if (addresses.Count > 0)
                    {
                        foreach (GatewayIPAddressInformation address in addresses)
                        {
                            _listOfGateways.Add(networkInterface.Name, address.Address.ToString());
                        }
                    }
                }
            }
                _dict.Add(iP, subnet);
                _myList.Add(_listOfIPs);
                _myList.Add(_listOfGateways);
                _myList.Add(_listOfSubnets);
        }
        return _myList;
    }
    public static Dictionary<string,string> IPAddressList
    {
        get
        {
            if ( _listOfIPs == null || _listofSubnets == null || _listOfGateways == null )
                GetAllNetworkInfo()
            return _listOfIPs;
        }
    }
    public static Dictionary<string,string> SubnetList
    {
        get
        {
            if ( _listOfIPs == null || _listOfSubnets == null || _listOfGateways == null )
                GetAllNetworkInfo()
            return _listOfSubnets;
        }
    }
    public static Dictionary<string,string> GatewayList
    {
        get
        {
            if ( _listOfIPs == null || _listofSubnets == null || _listOfGateways == null )
                GetAllNetworkInfo()
            return _listOfGateways;
        }
    }
