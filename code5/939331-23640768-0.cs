    public Interface IPortListGetter
    {
       void GetPortList();
    }
    var natDevice = NatDiscovery.Discover(); 
    var portGetter = natDevice as IPortListGetter;
    if (portGetter != null)
    {  
        portGetter.GetPortList();
    }
    
