    var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
    var dataPlanStatus = connectionProfile.GetDataPlanStatus();
    ulong? outboundBandwidth = dataPlanStatus.OutboundBitsPerSecond;
    if (outboundBandwidth.HasValue)
    {
        System.Diagnostics.Debug.WriteLine("OutboundBitsPerSecond : " + outboundBandwidth + "\n");
    }
    else
    {
        System.Diagnostics.Debug.WriteLine("OutboundBitsPerSecond : Not Defined\n");
    }
