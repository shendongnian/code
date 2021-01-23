    public void InitializeDictionaries()
    {
        mapIP1 = Devices.ToDictionary(x => x.IPaddress1);
        mapIP2 = Devices.ToDictionary(x => x.IPaddress2);
        mapIP3 = Devices.ToDictionary(x => x.IPaddress3);
    }
