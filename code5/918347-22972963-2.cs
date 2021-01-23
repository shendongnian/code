    public class NetworkInformation
    {
    private static Dictionary<string, List<string>> _listOfIPs = null;
    private static Dictionary<string, List<string>> _listOfSubnets = null;
    private static Dictionary<string, List<string>> _listOfGateways = null;
    private static List<Dictionary<string, List<string>>> _myList = new List<Dictionary<string, List<string>>>();
    public static object GetAllNetworkInfo()
    {
        if ( _listOfIPs == null || _listOfSubnets == null || _listofGateways == null ) {
            _listOfIPs = new Dictionary<string, List<string>();
            _listOfSubnets = new Dictionary<string, List<string>();
            _listOfGateways = new Dictionary<string, List<string>();
         } else {
             _listOfIPs.Clear();
             _listOfSubnets.Clear();
             _listOfGateways.Clear();
         }
         _myList.Clear();
        NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface networkInterface in networkInterfaces)
        {
            _listOfIPs.Add( networkInterface.Name, new List<string>);
            _listOfSubnets.Add( networkInterface.Name, new List<string>);
            _listOfGateways.Add( neworkdInterface.Name, new List<string>);
            IPInterfaceProperties adapterProperties = networkInterface.GetIPProperties();
            GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
            if (networkInterface.OperationalStatus == OperationalStatus.Up)
            {
                UnicastIPAddressInformationCollection unicastIPC = networkInterface.GetIPProperties().UnicastAddresses;
                foreach (UnicastIPAddressInformation unicast in unicastIPC)
                {
                    if (unicast.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        _listOfIPs[ networkInterface.Name ].Add(unicast.Address.ToString());
                        _listOfSubnets[ networkInterface.Name].Add(unicast.IPv4Mask.ToString());
                    }
                    if (addresses.Count > 0)
                    {
                        foreach (GatewayIPAddressInformation address in addresses)
                        {
                            _listOfGateways[ networkInterface.Name ].Add( address.Address.ToString());
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
